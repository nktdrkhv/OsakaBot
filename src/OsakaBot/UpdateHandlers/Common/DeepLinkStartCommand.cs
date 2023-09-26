using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messagies;

[Command(prefix: '/', argumentsMode: ArgumentsMode.Require, "start")]
public sealed class DeepLinkStartCommand : MessageHandler
{
    protected async override Task HandleAsync(IContainer<Message> cntr)
    {
        
    }
}