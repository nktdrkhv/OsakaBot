using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Reporting;

[Table("Report")]
public class Report : ITitled
{
    public int ReportId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Title { get; private set; }
    public ICollection<IncludedDialogue> IncludedDialogues { get; private set; } = null!;

    public ICollection<CrewMember> Assistants { get; set; } = null!;
    public ICollection<SentReport> SentReports { get; set; } = null!;

    public Report(string name, string title, params IncludedDialogue[] dialogues)
    {
        Name = name;
        Title = title;
        IncludedDialogues = dialogues;
    }

    private Report() { }
}