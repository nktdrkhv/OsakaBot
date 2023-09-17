using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Commands;

[Table("BotCommand")]
public class BotCommand
{
    public int BotCommandId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Order { get; set; }

    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; } = null!;

    public ICollection<RegularUserRole>? RegularUserTarger { get; set; }

    public bool IsForCrew { get; set; } = false;
    public CrewMemberType? CrewTarget { get; set; }
}