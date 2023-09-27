using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class SendReportAssistantsContactsEffect : ChatChangingEffectBase
{
    [Column(nameof(ReportId))] public int ReportId { get; set; }
    [Column(nameof(Report))] public Report Report { get; set; } = null!;

    public SendReportAssistantsContactsEffect(Report report, string label, byte order = 0) : base(EffectType.SendReportAssistantsContacts, order)
    {
        Report = report;
        Source = new(label);
    }

    private SendReportAssistantsContactsEffect() { }

    public override void SetArguments(string[] args) { }
}

public class SendReportAssistantsContactsEffectApplier : IEffectApplier<SendReportAssistantsContactsEffect>
{
    private readonly ITelegramBotClient _botClient;

    public SendReportAssistantsContactsEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (SendReportAssistantsContactsEffect)effect;
        await Task.CompletedTask;
    }
}