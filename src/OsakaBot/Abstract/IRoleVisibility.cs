namespace Osaka.Bot.Abstract;

public interface IRoleVisibility
{
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }
}