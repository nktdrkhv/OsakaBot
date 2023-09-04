using System.Linq.Expressions;
using SQLitePCL;
using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;

namespace Osaka.Bot.ChatFlow;

public class ChatFlowService : IChatFlowService
{
    private readonly IInnerUserStorge _innerUserStorge;
    private readonly IChatScopeService _chatScopeService;
    private readonly ITriggerService _triggerService;
    private readonly IValidationService _validationService;
    private readonly IInputService _inputService;

    public ChatFlowService(IInnerUserStorge innerUserStorge, IChatScopeService chatScopeService, ITriggerService triggerService, IValidationService validationService, IInputService inputService)
    {
        _innerUserStorge = innerUserStorge;
        _chatScopeService = chatScopeService;
        _triggerService = triggerService;
        _validationService = validationService;
        _inputService = inputService;
    }

    public async ValueTask<InnerUserState> SubmitCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var user = await _innerUserStorge.RetrieveInnerUser(callbackQuery.From);
        if (callbackQuery?.Data is string queryData)
        {
            if (await _triggerService.FromEncodedPreparedAsync(user, queryData) is Trigger preparedTrigger)
            {
                await _inputService.AssignFromTriggerAsync(user, preparedTrigger);
                await _triggerService.ExecuteAsync(user, preparedTrigger);
            }
            else if (await _triggerService.FromEncodedStoredAsync(user, queryData) is Trigger storedTrigger && storedTrigger.AllowOutOfScope)
            {
                await _triggerService.ExecuteAsync(user, storedTrigger);
            }
            else if (callbackQuery.Message?.MessageId is int msgId)
            {
                var removeInlineKeyboard = new RemoveInlineKeyboardEffect() { TargetMessageId = msgId };
                await _triggerService.ExecuteAsync(user, removeInlineKeyboard);
            }
        }
        return user.State;
    }

    public async ValueTask<InnerUserState> SubmitMediaGroupAsync(IEnumerable<Message> mediaGroup) =>
        await SubmitInnerMessage(mediaGroup.First().From!, new(mediaGroup));

    public async ValueTask<InnerUserState> SubmitMessageAsync(Message message) =>
        await SubmitInnerMessage(message.From!, new(message));

    private async ValueTask<InnerUserState> SubmitInnerMessage(User user, InnerMessage innerMessage)
    {
        var innerUser = await _innerUserStorge.RetrieveInnerUser(user);
        if (innerMessage.Text?.OriginalText is string messageText && await _triggerService.FromPlainPreparedAsync(innerUser, messageText) is Trigger replyTrigger)
        {
            innerMessage!.Type = InnerMessageType.TextFromButton;
            if (await _inputService.IsThereAnyActiveDialogue(innerUser))
                await _inputService.AssignFromTriggerAsync(innerUser, replyTrigger, innerMessage);
            await _chatScopeService.SetInputToReasonAsync(innerUser, replyTrigger, innerMessage);
            await _triggerService.ExecuteAsync(innerUser, replyTrigger);
        }
        else
        {
            if (await _validationService.ValidateAsync(innerUser, innerMessage!) &&
                await _triggerService.FromValidCustomInput(innerUser) is Trigger triggerForValid)
            {
                await _chatScopeService.SetInputToActiveAsync(innerUser, innerMessage!);
                if (await _inputService.IsThereAnyActiveDialogue(innerUser))
                    await _inputService.AssignFromTriggerAsync(innerUser, triggerForValid, innerMessage!);
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
                    if (await _inputService.IsThereAnyActiveDialogue(innerUser))
                        await _inputService.AssignFromTriggerAsync(innerUser, triggerForInvalid, innerMessage!);
                    await _triggerService.ExecuteAsync(innerUser, triggerForInvalid);
                }
            }
        };
        return innerUser.State;
    }
}