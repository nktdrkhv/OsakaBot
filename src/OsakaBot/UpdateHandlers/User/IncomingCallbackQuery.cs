using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.User.CallbackQueries;

[UserNumericState(UserStateKeeperAccessor.Regular, 0), Order(6)]
public sealed class IncomingCallbackQuery : CallbackQueryHandler
{
    private readonly IChatFlowService _chatFlowService;

    public IncomingCallbackQuery(IChatFlowService chatFlowService) => _chatFlowService = chatFlowService;

    protected override async Task HandleAsync(IContainer<CallbackQuery> cntr)
    {
        await cntr.AnswerAsync();
        await _chatFlowService.SubmitCallbackQueryAsync(cntr.Update);
    }
}