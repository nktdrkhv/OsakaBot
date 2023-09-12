namespace Osaka.Bot.Reporting;

public class Report : ITitled
{
    public int ReportId { get; set; }
    public string? Title { get; set; }
    public ICollection<IncludedDialog> IncludedDialogues { get; set; } = null!;
    public ICollection<CrewMember> Assistants { get; set; } = null!;
    public ICollection<SentReport> SentReports { get; set; } = null!;
}