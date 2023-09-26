using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.InputSystem;

//[PrimaryKey(nameof(AttachedTo), nameof(AttachedTo))]
[Table("DialogueField")]
public class DialogueField
{
    public int DialogueFieldId { get; private set; }
    public int Order { get; private set; }

    public string AssignToName { get; private set; } = null!;
    public Variable AssignTo { get; private set; } = null!;

    public int AttachedToId { get; private set; }
    public Dialogue AttachedTo { get; private set; } = null!;

    public ICollection<IncludedPost> IncludedPosts { get; private set; } = null!;

    public DialogueField(int order, Variable assignTo, params IncludedPost[] posts)
    {
        Order = order;
        AssignTo = assignTo;
        IncludedPosts = posts;
    }

    private DialogueField() { }
}