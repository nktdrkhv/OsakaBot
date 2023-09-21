namespace Osaka.Bot.Abstract;

public interface IRoleVisibility
{
    public ICollection<RegularUserRole>? RoleVisibility { get; }
    public string? PhraseVisibility { get; }
}