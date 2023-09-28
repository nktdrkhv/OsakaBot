using System.Security.Cryptography;
using MixERP.Net.VCards.Extensions;
using Telegram.Bot.Types;
using TelegramUpdater;

namespace Osaka.Bot.ChatFlow;

public class ChatFlowService : IChatFlowService
{
    private readonly ITriggerService _triggerService;
    private readonly IValidationService _validationService;
    private readonly IInputService _inputService;
    private readonly ITextCommandService _textCommandService;
    private readonly IChatScopeService _chatScopeService;
    private readonly IRepository _repository;

    public ChatFlowService(IChatScopeService chatScopeService, ITriggerService triggerService, IValidationService validationService, IInputService inputService, ITextCommandService textCommandService, IRepository repository)
    {
        _chatScopeService = chatScopeService;
        _triggerService = triggerService;
        _validationService = validationService;
        _inputService = inputService;
        _textCommandService = textCommandService;
        _repository = repository;
    }

    public async ValueTask SubmitCommandAsync(Message command)
    {
        var innerUser = await _repository.GetInnerUser(command.From!, true)
            ?? throw new NullReferenceException("InnerUser has to exist on the Chat Flow");
        await _textCommandService.ExecuteCommand(innerUser, command.Text!);
        await _chatScopeService.SetInputToCustomAsync(innerUser, new(command), new(OrphanType.AtTheBegginnigOfTheScope));
    }

    public async ValueTask SubmitCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var innerUser = await _repository.GetInnerUser(callbackQuery.From, true)
            ?? throw new NullReferenceException("InnerUser has to exist on the Chat Flow");
        if (callbackQuery?.Data is string queryData)
        {
            var args = queryData.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 2) return;
            switch (args[0])
            {
                case ButtonInline.SimplePrefix: // s:o3osd
                    if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger preparedTrigger)
                    {
                        await _inputService.FromButtonTriggerAsync(innerUser, preparedTrigger);
                        await _triggerService.ExecuteAsync(innerUser, preparedTrigger);
                    }
                    else if (await _triggerService.FromEncodedStoredAsync(innerUser, args[1]) is Trigger storedTrigger)
                        await _triggerService.ExecuteAsync(innerUser, storedTrigger);
                    else if (callbackQuery.Message?.MessageId is int sMsgId)
                        await RemoveInlineKeyBoard(innerUser, sMsgId);
                    break;
                case ButtonInline.InsidePrefix: // i:dwo2q:31.03.2022 || i:#:31.03.2023
                    if (args.Length == 3)
                    {
                        if (args[1] == "#" &&
                            await _validationService.ValidateAsync(innerUser, args[2]) &&
                            await _triggerService.FromValidCustomInput(innerUser) is Trigger triggerForValid)
                        {
                            await _inputService.FromButtonTriggerAsync(innerUser, triggerForValid, args[2]);
                            await _triggerService.ExecuteAsync(innerUser, triggerForValid);
                        }
                        else if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger iTrigger)
                        {
                            await _inputService.FromButtonTriggerAsync(innerUser, iTrigger, args[2]);
                            await _triggerService.ExecuteAsync(innerUser, iTrigger);
                        }
                        else if (callbackQuery.Message?.MessageId is int iMsgId)
                            await RemoveInlineKeyBoard(innerUser, iMsgId);
                    }
                    else if (callbackQuery.Message?.MessageId is int iMsgId)
                        await RemoveInlineKeyBoard(innerUser, iMsgId);
                    break;
                case ButtonInline.DynamicPrefix: // d:sa2qa:cc:r ... todo: should be d:sa2qa:cc:4:r, which means dynamic inlinekeyboard update
                    // todo: execute outside of the scope
                    if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger dTrigger && args.Length >= 3)
                        await _triggerService.ExecuteAsync(innerUser, dTrigger, args[1..]);
                    else if (callbackQuery.Message?.MessageId is int dMsgId)
                        await RemoveInlineKeyBoard(innerUser, dMsgId);
                    break;
                default:
                    if (callbackQuery.Message?.MessageId is int msgId)
                        await RemoveInlineKeyBoard(innerUser, msgId);
                    break;
            }
        }
    }

    private async ValueTask RemoveInlineKeyBoard(InnerUser user, int targetMessageId)
    {
        var removeInlineKeyboard = new RemoveInlineKeyboardEffect(new(targetMessageId));
        await _triggerService.ExecuteAsync(user, removeInlineKeyboard);
    }

    public async ValueTask SubmitMediaGroupAsync(IEnumerable<Message> mediaGroup) =>
        await SubmitInnerMessageAsync(mediaGroup.First().From!, new(mediaGroup));

    public async ValueTask SubmitMessageAsync(Message message) =>
        await SubmitInnerMessageAsync(message.From!, new(message));

    private async ValueTask SubmitInnerMessageAsync(User user, InnerMessage innerMessage)
    {
        var innerUser = await _repository.GetInnerUser(user, true)
            ?? throw new NullReferenceException("InnerUser has to exist on the Chat Flow");
        if (innerMessage.Text?.OriginalText is string messageText && await _triggerService.FromPlainPreparedAsync(innerUser, messageText) is Trigger replyTrigger)
        {
            innerMessage!.Type = InnerMessageType.TextFromButton;
            await _inputService.FromMessageTriggerAsync(innerUser, replyTrigger, innerMessage);
            await _chatScopeService.SetInputToReasonAsync(innerUser, innerMessage, replyTrigger);
            await _triggerService.ExecuteAsync(innerUser, replyTrigger);
        }
        else
        {
            if (await _validationService.ValidateAsync(innerUser, innerMessage!) &&
                await _triggerService.FromValidCustomInput(innerUser) is Trigger triggerForValid)
            {
                await _chatScopeService.SetInputToActiveAsync(innerUser, innerMessage!);
                await _inputService.FromMessageTriggerAsync(innerUser, triggerForValid, innerMessage!);
                await _triggerService.ExecuteAsync(innerUser, triggerForValid);
            }
            else if (await _triggerService.FromInvalidCustomInput(innerUser) is Trigger triggerForInvalid)
            {
                if (await _chatScopeService.HasCorrectionLoop(innerUser))
                {
                    await _triggerService.ExecuteAsync(innerUser, triggerForInvalid);
                    await _chatScopeService.SetInputToActiveAsync(innerUser, innerMessage!);
                }
                else
                {
                    await _chatScopeService.SetInputToActiveAsync(innerUser, innerMessage!);
                    await _inputService.FromMessageTriggerAsync(innerUser, triggerForInvalid, innerMessage!);
                    await _triggerService.ExecuteAsync(innerUser, triggerForInvalid);
                }
            }
            else
            {
                var removeShowedMessage = new RemoveShowedMessageEffect(new(innerMessage.CauseMessageId));
                await _triggerService.ExecuteAsync(innerUser, removeShowedMessage);
            }
        };
    }
}