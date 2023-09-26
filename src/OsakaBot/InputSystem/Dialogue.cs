using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("Dialogue")]
public class Dialogue : ITitled
{
    public int DialogueId { get; private set; }
    public string? Title { get; private set; }
    public ICollection<DialogueField> Fields { get; private set; } = null!;
    public ICollection<IncludedDialogue>? BeingPartOf { get; private set; }

    public Dialogue(string title, params DialogueField[] fields) => (Title, Fields) = (title, fields);
    private Dialogue() { }
}