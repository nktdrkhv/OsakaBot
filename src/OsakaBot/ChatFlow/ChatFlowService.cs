using System.Security.Cryptography;
using MixERP.Net.VCards.Extensions;
using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public class ChatFlowService : IChatFlowService
{
    private readonly ITriggerService _triggerService;
    private readonly IValidationService _validationService;
    private readonly IInputService _inputService;
    private readonly IChatScopeService _chatScopeService;
    private readonly IRepository _repository;

    public ChatFlowService(IChatScopeService chatScopeService, ITriggerService triggerService, IValidationService validationService, IInputService inputService, IRepository repository)
    {
        _chatScopeService = chatScopeService;
        _triggerService = triggerService;
        _validationService = validationService;
        _inputService = inputService;
        _repository = repository;
    }

    public async ValueTask SubmitCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var innerUser = await _repository.GetInnerUser(callbackQuery.From, true);
        if (callbackQuery?.Data is string queryData)
        {
            var args = queryData.Split(':', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 2) return;
            switch (args[0])
            {
                case "s": // s:o3osd
                    if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger preparedTrigger)
                    {
                        await _inputService.FromButtonTriggerAsync(innerUser, preparedTrigger);
                        await _triggerService.ExecuteAsync(innerUser, preparedTrigger);
                    }
                    else if (await _triggerService.FromEncodedStoredAsync(innerUser, args[1]) is Trigger storedTrigger && storedTrigger.AllowOutOfScope)
                        await _triggerService.ExecuteAsync(innerUser, storedTrigger);
                    else if (callbackQuery.Message?.MessageId is int sMsgId)
                        await RemoveInlineKeyBoard(innerUser, sMsgId);
                    break;
                case "i": // i:dwo2q:31.03.2022
                    if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger iTrigger && args.Length == 3)
                        await _inputService.FromButtonTriggerAsync(innerUser, iTrigger, args[2]);
                    else if (callbackQuery.Message?.MessageId is int iMsgId)
                        await RemoveInlineKeyBoard(innerUser, iMsgId);
                    break;
                case "d": // d:sa2qa:cc:4:r
                    // todo: execute outside of the scope
                    if (await _triggerService.FromEncodedPreparedAsync(innerUser, args[1]) is Trigger dTrigger && args.Length >= 3)
                        await _triggerService.ExecuteAsync(innerUser, dTrigger, args[2..]);
                    else if (callbackQuery.Message?.MessageId is int dMsgId)
                        await RemoveInlineKeyBoard(innerUser, dMsgId);
                    break;
                default:
                    if (callbackQuery.Message?.MessageId is int msgId)
                        await RemoveInlineKeyBoard(innerUser, msgId);
                    break;
            }
        }
        return;
    }

    private async ValueTask RemoveInlineKeyBoard(InnerUser user, int targetMessageId)
    {
        var removeInlineKeyboard = new RemoveInlineKeyboardEffect() { TargetMessageId = targetMessageId };
        await _triggerService.ExecuteAsync(user, removeInlineKeyboard);
    }

    public async ValueTask SubmitMediaGroupAsync(IEnumerable<Message> mediaGroup) =>
        await SubmitInnerMessage(mediaGroup.First().From!, new(mediaGroup));

    public async ValueTask SubmitMessageAsync(Message message) =>
        await SubmitInnerMessage(message.From!, new(message));

    private async ValueTask SubmitInnerMessage(User user, InnerMessage innerMessage)
    {
        var innerUser = await _repository.GetInnerUser(user, true);
        if (innerMessage.Text?.OriginalText is string messageText && await _triggerService.FromPlainPreparedAsync(innerUser, messageText) is Trigger replyTrigger)
        {
            innerMessage!.Type = InnerMessageType.TextFromButton;
            await _inputService.FromMessageTriggerAsync(innerUser, replyTrigger, innerMessage);
            await _chatScopeService.SetInputToReasonAsync(innerUser, replyTrigger, innerMessage);
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
        };
        return;
    }
}