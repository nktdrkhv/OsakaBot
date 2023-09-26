using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Reporting;

[Table("IncludedDialogue")]
public class IncludedDialogue
{
    public int IncludedDialogueId { get; private set; }
    public DialogueIncludingType IncludingType { get; private set; } = DialogueIncludingType.AsNormal;
    public int Order { get; private set; }

    public int DialogueId { get; private set; }
    public Dialogue Dialogue { get; private set; } = null!;

    public int ReportId { get; private set; }
    public Report Report { get; private set; } = null!;

    public IncludedDialogue(int order, Dialogue dialogue, DialogueIncludingType includingType = DialogueIncludingType.AsNormal)
    {
        Dialogue = dialogue;
        IncludingType = includingType;
        Order = order;
    }

    private IncludedDialogue() { }
}