using System.ComponentModel.DataAnnotations;

namespace Osaka.Bot.UserSpecific;

public class InnerUser
{
    [Key]
    public long TelegramUserId { get; set; }
    public string OriginalFullName { get; set; } = null!;
    public InnerUserState State { get; set; } = null!;
    public InnerUserType Type { get; set; }
    public RegularUserRole? Role { get; set; }
    public Contact? Contact { get; set; }
}