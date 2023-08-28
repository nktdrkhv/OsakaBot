namespace Osaka.Bot.Commands;

public class BotCommand
{
    public int CommandId { get; set; }
    public string Label { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Trigger Trigger { get; set; } = null!;
    public InnerUserType Visibility { get; set; } = InnerUserType.None | InnerUserType.Regular;
}