namespace Osaka.Bot.InputSystem;

public class Dialogue
{
    public int DialogueId { get; set; }
    public string Title { get; set; } = null!;
    public ICollection<DialogueField> Parts { get; set; } = null!;
}