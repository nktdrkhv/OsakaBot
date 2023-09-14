namespace Osaka.Bot.UserSpecific;

public class RegularUserRole
{
    public int RegularUserRoleId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<BotCommand>? Commands { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public ICollection<ButtonBase>? Buttons { get; set; }
}