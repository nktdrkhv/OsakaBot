using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("Dialogue")]
public class Dialogue : ITitled, ILabeled
{
    public int DialogueId { get; set; }
    public string? Title { get; set; }
    public string? Label { get; set; }
    public ICollection<DialogueField> Fields { get; set; } = null!;
    public ICollection<IncludedDialog>? BeingPartOf { get; set; }
}