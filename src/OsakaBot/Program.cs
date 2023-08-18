using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramUpdater;
using TelegramUpdater.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<BotConfiguration>(context.Configuration.GetSection(BotConfiguration.Section));
        services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    var configuration = sp.GetService<IOptions<BotConfiguration>>()!.Value;
                    var clientOptions = new TelegramBotClientOptions(
                        token: configuration.BotToken,
                        baseUrl: configuration.BaseUrl,
                        useTestEnvironment: configuration.IsTestEnv);
                    return new TelegramBotClient(clientOptions, httpClient);
                });
        services.AddTelegramUpdater<Worker>(
            new UpdaterOptions(
                flushUpdatesQueue: true,
                allowedUpdates: Array.Empty<UpdateType>()),
            (builder) => builder
                .AutoCollectScopedHandlers()
                .AddDefaultExceptionHandler());
        services.AddMemoryCache();
    })
    .Build();

await host.RunAsync();
