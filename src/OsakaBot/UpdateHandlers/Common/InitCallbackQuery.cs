using Humanizer;
using Telegram.Bot.Types;
using TelegramUpdater;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.CallbackQueries;

[UserNumericState(((int)UserStateType.Regular))]
public sealed class InitCallbackQuery : CallbackQueryHandler
{
    protected override Task HandleAsync(IContainer<CallbackQuery> cntr)
    {
        cntr.DeleteNumericState(UserStateType.Regular.ToString(), From);
        throw new NotImplementedException();
    }
}