using Microsoft.Extensions.Options;
using Sqids;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramUpdater;
using TelegramUpdater.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient();
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
                maxDegreeOfParallelism: 32,
                flushUpdatesQueue: false,
                allowedUpdates: Array.Empty<UpdateType>()),
            (builder) => builder
                //.AutoCollectScopedHandlers("UpdateHandlers.User")
                //.AutoCollectScopedHandlers("UpdateHandlers.Support")
                //.AutoCollectScopedHandlers("UpdateHandlers.Admin")
                .AutoCollectScopedHandlers("UpdateHandlers.Common")
                .AddDefaultExceptionHandler());
        services.AddDbContext<BotDbContext>();
        services.AddGenericRepository<BotDbContext>();
        services.AddSingleton(new SqidsEncoder(new()
        {
            Alphabet = "abcdefghijklmnopqrstuvwxyz1234567890",
            MinLength = 4,
        }));
        services.AddHostedService<Worker>();
        services.AddHostedService<WeatherService>();
        services.AddHostedService<UserStateKeeperAccessor>();
        services.AddOsaka();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    try
    {
        var botcpf = scope.ServiceProvider.GetService<IOptions<BotConfiguration>>();
        Console.WriteLine(botcpf!.Value.BotToken);
        var db = scope.ServiceProvider.GetService<BotDbContext>();
        if (!db!.Posts.Any())
        {
            var seed = new DataSeed();
            seed.Initialize(db);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.InnerException);
        return;
    }
}

await host.RunAsync();
