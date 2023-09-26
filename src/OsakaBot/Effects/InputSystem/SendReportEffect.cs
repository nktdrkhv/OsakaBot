using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public sealed class SendReportEffect : EffectBase
{
    public int ReportId { get; set; }
    public Report Report { get; set; } = null!;

    public SendReportEffect(Report report, byte order = 0) : base(EffectType.SendReport, order)
        => Report = report;

    private SendReportEffect() { }

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