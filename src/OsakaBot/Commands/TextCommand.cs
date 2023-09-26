using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Commands;

[Table("TextCommand")]
public class TextCommand : IRoleVisibility
{
    public int TextCommandId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte Order { get; set; }

    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; } = null!;

    public ICollection<UserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    // public bool IsForCrew { get; set; } = false;
    // public CrewMemberType? CrewTarget { get; set; }
}