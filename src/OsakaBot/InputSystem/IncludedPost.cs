using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("IncludedPost")]
public class IncludedPost
{
    public int IncludedPostId { get; private set; }
    public PostIncludingType IncludingType { get; private set; } = PostIncludingType.UserInput;
    public AutoInputType? AutoInputType { get; private set; }

    public int PostId { get; private set; }
    public Post Post { get; private set; } = null!;

    public int DialogueFieldId { get; private set; }
    public DialogueField DialogueField { get; private set; } = null!;

    public IncludedPost(Post post, PostIncludingType includingType = PostIncludingType.UserInput, AutoInputType? autoInput = null)
    {
        Post = post;
        IncludingType = includingType;
        AutoInputType = autoInput;
    }

    private IncludedPost() { }
}