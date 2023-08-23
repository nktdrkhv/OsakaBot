using Telegram.Bot.Types;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messagies;

public sealed class InitMassage : MessageHandler
{
    protected override Task HandleAsync(IContainer<Message> cntr)
    {
        throw new NotImplementedException();
    }
}