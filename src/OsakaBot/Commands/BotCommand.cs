namespace Osaka.Bot.Commands;

public class BotCommand
{
    public int BotCommandId { get; set; }
    public string Label { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; } = null!;

    public ICollection<RegularUserRole>? RegularUserTarger { get; set; }

    public bool IsForCrew { get; set; }
    public CrewMemberType? CrewTarget { get; set; }
}