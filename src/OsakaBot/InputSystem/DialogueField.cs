using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.InputSystem;

//[PrimaryKey(nameof(AttachedTo), nameof(AttachedTo))]
[Table("DialogueField")]
public class DialogueField
{
    public int DialogueFieldId { get; set; }

    public string AssignToName { get; set; } = null!;
    public int AttachedToId { get; set; }

    public Variable AssignTo { get; set; } = null!;
    public Dialogue AttachedTo { get; set; } = null!;
    public ICollection<IncludedPost> IncludedPost { get; set; } = null!;
}