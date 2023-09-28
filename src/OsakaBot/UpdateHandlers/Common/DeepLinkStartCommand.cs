using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messages;


[Order(1), Command(prefix: '/', argumentsMode: ArgumentsMode.Require, "start")]
public sealed class DeepLinkStartCommand : MessageHandler
{
    private readonly IRepository _repository;
    private readonly ICrewService _crewService;

    public DeepLinkStartCommand(IRepository repository, ICrewService crewService)
    {
        _repository = repository;
        _crewService = crewService;
    }

    protected async override Task HandleAsync(IContainer<Message> cntr)
    {
        if (cntr.TryParseCommandArgs(out string? args) && args != null)
        {

        }
    }
}