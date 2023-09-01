namespace Osaka.Bot.InputSystem;

public class DialogueField
{
    public int DialogueFieldId { get; set; }
    public Dialogue AttachedTo { get; set; } = null!;
    public Variable AssignTo { get; set; } = null!;
    public IncludedPost Post { get; set; } = null!;
}