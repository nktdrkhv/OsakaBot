using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

[Table("InnerUser")]
public class InnerUser
{
    public int InnerUserId { get; set; }
    public long TelegramUserId { get; set; }
    public string OriginalFullName { get; set; } = null!;
    public string? Username { get; set; }
    public InnerUserState State { get; set; } = null!;
    public InnerUserType Type { get; set; }
    public RegularUserRole? Role { get; set; }
    public InnerContact? Contact { get; set; }

    public InnerUser(User user)
    {
        TelegramUserId = user.Id;
        OriginalFullName = user.LastName is null ? user.FirstName : $"{user.FirstName} {user.LastName}";
        Username = user.Username;
        State = new()
        {
            CurrentType = InnerUserType.None,
            ChatFlowType = ChatFlowType.Common,
        };
        Type = InnerUserType.None;
    }
}