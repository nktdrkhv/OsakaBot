using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messages;

[Order(2), Command(prefix: '/', argumentsMode: ArgumentsMode.NoArgs, "start")]
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
        if (cntr.Updater.ContainsKey($"startreq_{cntr.SenderId()!}"))
        {
            cntr.Updater.TryRemove($"startreq_{cntr.SenderId()!}", out var lessons);
            (DateTime time, int reason, int sayStart) = (Tuple<DateTime, int, int>)lessons!;
            if (DateTime.UtcNow.Subtract(time) < TimeSpan.FromDays(2))
            {
                await cntr.BotClient.DeleteMessageAsync(cntr.SenderId()!, sayStart);
                await cntr.BotClient.DeleteMessageAsync(cntr.SenderId()!, reason);
            }
        }

        //if (_repository.GetInnerUser(cntr.Sender()))

        StopPropagation();
    }
}