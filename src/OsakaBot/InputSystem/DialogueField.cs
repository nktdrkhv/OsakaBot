using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("DialogueField")]
public class DialogueField
{
    public int DialogueFieldId { get; set; }

    public string AssignToId { get; set; } = null!;
    public int AttachedToId { get; set; }
    public int IncludedPostId { get; set; }

    public Variable AssignTo { get; set; } = null!;
    public Dialogue AttachedTo { get; set; } = null!;
    public ICollection<IncludedPost> IncludedPost { get; set; } = null!;
}