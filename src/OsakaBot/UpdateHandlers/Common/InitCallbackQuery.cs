using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.CallbackQueries;

public sealed class InitCallbackQuery : CallbackQueryHandler
{
    protected override Task HandleAsync(IContainer<CallbackQuery> cntr)
    {

        throw new NotImplementedException();
    }
}