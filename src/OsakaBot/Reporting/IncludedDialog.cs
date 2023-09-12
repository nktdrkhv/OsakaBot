using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Reporting;

[Table("IncludedDialogue")]
public class IncludedDialog
{
    public int IncludedDialogueId { get; set; }
    public DialogueIncludingType IncludingType { get; set; } = DialogueIncludingType.AsNormal;

    public int DialogueId { get; set; }
    public Dialogue Dialogue { get; set; } = null!;

    public int ReportId { get; set; }
    public Report Report { get; set; } = null!;
}