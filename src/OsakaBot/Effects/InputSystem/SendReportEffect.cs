using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public class SendReportEffect : EffectBase
{
    public int ReportId { get; set; }
    public Report Report { get; set; } = null!;

    public SendReportEffect() => Type = EffectType.SendReport;

    public override void SetArguments(string[] args) { }
}

public class SendReportEffectApplier : IEffectApplier<SendReportEffect>
{
    private readonly ITelegramBotClient _botClient;

    public SendReportEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (SendReportEffect)effect;
        await Task.CompletedTask;
    }
}