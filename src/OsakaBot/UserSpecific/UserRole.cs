using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.UserSpecific;

[Table("UserRole")]
public class UserRole
{
    public int UserRoleId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<TextCommand>? Commands { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public ICollection<ButtonBase>? Buttons { get; set; }
}