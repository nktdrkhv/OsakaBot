namespace Osaka.Bot.Abstract;

public interface IRoleVisibility
{
    public ICollection<UserRole>? RoleVisibility { get; }
    public string? PhraseVisibility { get; }
}