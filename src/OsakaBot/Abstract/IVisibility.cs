namespace Osaka.Bot.Abstract;

public interface IVisible
{
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }
}