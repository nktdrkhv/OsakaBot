namespace Osaka.Bot.InputSystem;

public class Dialogue : ITitled, ILabeled
{
    public int DialogueId { get; set; }
    public string? Title { get; set; }
    public string? Label { get; set; }
    public ICollection<DialogueField> Parts { get; set; } = null!;
}