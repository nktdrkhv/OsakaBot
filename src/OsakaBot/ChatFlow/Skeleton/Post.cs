using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("Post")]
public class Post : IRoleVisibility, ILabeled, ITitled, IMetaMark
{
    public int PostId { get; set; }

    public string? Label { get; set; }
    public string? Title { get; set; }
    public string? MetaMark { get; set; }

    public int ContentId { get; set; }
    public InnerMessage Content { get; set; } = null!;

    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    public int? KeyboardId { get; set; }
    public KeyboardBase? Keyboard { get; set; }

    public int? UserInputId { get; set; }
    public UserInput? UserInput { get; set; }

    public int? OnUserScopeClearId { get; set; }
    public Trigger? OnUserScopeClear { get; set; }
}