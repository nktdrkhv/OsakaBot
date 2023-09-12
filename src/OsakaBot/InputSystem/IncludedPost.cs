using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("IncludedPost")]
public class IncludedPost
{
    public int IncludedPostId { get; set; }
    public IncludingType IncludingType { get; set; } = IncludingType.UserInput;
    public AutoInputType? AutoInputType { get; set; }

    public int DialogueFieldId { get; set; }
    public DialogueField DialogueField { get; set; } = null!;

    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}