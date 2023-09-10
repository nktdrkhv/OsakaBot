namespace Osaka.Bot.ChatFlow.Skeleton;

public class Post : IRoleVisibility, ILabeled, ITitled
{
    public int PostId { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }
    public string? InputMeta { get; set; }
    public InnerMessage Content { get; set; } = null!;
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }
    public KeyboardBase? Keyboard { get; set; }
    public UserInput? UserInput { get; set; }
    public Trigger? OnUserScopeClear { get; set; }
}