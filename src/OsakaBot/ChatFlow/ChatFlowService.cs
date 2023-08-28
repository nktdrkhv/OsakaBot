using SQLitePCL;
using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public class ChatFlowService : IChatFlowService
{
    private readonly IInnerUserStorge _innerUserStorge;
    private readonly ITriggerService _triggerService;
    private readonly IValidationService _validationService;
    private readonly IDialogeService _dialogeService;

    public ChatFlowService(IInnerUserStorge innerUserStorge, ITriggerService triggerService, IValidationService validationService, IDialogeService dialogeService)
    {
        _innerUserStorge = innerUserStorge;
        _triggerService = triggerService;
        _validationService = validationService;
        _dialogeService = dialogeService;
    }

    public async ValueTask<InnerUserState> SubmitCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        var user = await _innerUserStorge.RetrieveInnerUser(callbackQuery.From);
        if (callbackQuery?.Data is string queryData &&
            await _triggerService.FromEncodedAsync(user, queryData) is Trigger trigger)
        {
            await _dialogeService.AssignFromTriggerAsync(user, trigger);
            await _triggerService.ExecuteAsync(user, trigger);
        }
        return user.State;
    }

    public async ValueTask<InnerUserState> SubmitMessageAsync(Message message)
    {
        var user = await _innerUserStorge.RetrieveInnerUser(message.From!);
        if (message?.Text is string messageText && await _triggerService.FromPreparedAsync(user, messageText) is Trigger replyTrigger)
        {
            if (await _dialogeService.IsThereAnyActiveDialogue(user))
                await _dialogeService.AssignFromTriggerAsync(
                    user,
                    replyTrigger,
                    new(message.MessageId, new(messageText),
                    buttonOrigin: true));
            await _triggerService.ExecuteAsync(user, replyTrigger);
        }
        else
        {
            Trigger? customInputTrigger = await _validationService.ValidateAsync(user, new(message!))
                ? await _triggerService.FromCorrectCustomInput(user)
                : await _triggerService.FromIncorrectCustomInput(user);
            if (await _dialogeService.IsThereAnyActiveDialogue(user))
                await _dialogeService.AssignFromTriggerAsync(
                    user,
                    customInputTrigger!,
                    new(message!)
                );
            if (customInputTrigger is not null)
                await _triggerService.ExecuteAsync(user, customInputTrigger);
        };
        return user.State;
    }
}