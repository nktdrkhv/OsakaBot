using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("Post")]
public class Post : IRoleVisibility, ITitled, IMetaMark
{
    public int PostId { get; private set; }

    public string? Title { get; set; }
    public string? MetaMark { get; set; }

    public int ContentId { get; set; }
    public InnerMessage Content { get; set; } = null!;

    public ICollection<UserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    public int? KeyboardId { get; set; }
    public KeyboardBase? Keyboard { get; set; }

    public int? UserInputId { get; set; }
    public UserInput? UserInput { get; set; }

    public int? OnUserScopeClearId { get; set; }
    public Trigger? OnUserScopeClear { get; set; }
}