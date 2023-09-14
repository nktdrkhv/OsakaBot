using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Reporting;

[Table("CrewNotification")]
public class CrewNotification
{
    public int CrewNotificationId { get; set; }

    public int SentReportId { get; set; }
    public int CrewMemberId { get; set; }
    public int? ItselfId { get; set; }

    public SentReport SentReport { get; set; } = null!;
    public CrewMember CrewMember { get; set; } = null!;
    public InnerMessage? Itself { get; set; } = null!;

    public bool IsNotified { get; set; }
}
