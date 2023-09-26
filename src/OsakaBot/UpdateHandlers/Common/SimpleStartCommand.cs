using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messagies;

[Command(prefix: '/', argumentsMode: ArgumentsMode.NoArgs, "start")]
public sealed class SimpleStartCommand : MessageHandler
{
    private readonly IRepository _repository;
    private readonly ITextCommandService _textCommandService;

    public SimpleStartCommand(IRepository repository, ITextCommandService textCommandService)
    {
        _repository = repository;
        _textCommandService = textCommandService;
    }

    protected async override Task HandleAsync(IContainer<Message> cntr)
    {

    }
}