using Telegram.Bot.Polling;
using TelegramUpdater;
using TelegramUpdater.Hosting;

namespace Osaka.Bot.Services;

public class Worker : UpdateWriterServiceAbs
{
    public Worker(IUpdater updater) : base(updater)
    {
        updater.AddUserNumericStateKeeper(UserStateKeeperAccessor.Regular);
        updater.AddUserNumericStateKeeper(UserStateKeeperAccessor.Support);
        updater.AddUserNumericStateKeeper(UserStateKeeperAccessor.Admin);
    }

    public override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var reciever = new QueuedUpdateReceiver(Updater.BotClient);
                await foreach (var update in reciever.WithCancellation(stoppingToken))
                    await EnqueueUpdateAsync(update, stoppingToken);
            }
            catch
            { }
        }
    }
}