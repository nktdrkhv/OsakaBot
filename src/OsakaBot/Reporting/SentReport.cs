namespace Osaka.Bot.Reporting;

public class SentReport
{
    public int SentReportId { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public SentReportStatus Status { get; set; } = SentReportStatus.Unread;
    public string? DeclineReason { get; set; }

    public int ReportId { get; set; }
    public Report Report { get; set; } = null!;

    public int ByUserId { get; set; }
    public InnerUser ByUser { get; set; } = null!;

    public int? CrewOwnerId { get; set; }
    public CrewMember? CrewOwner { get; set; }

    public ICollection<CrewNotification> CrewNotifications { get; set; } = null!;
}
