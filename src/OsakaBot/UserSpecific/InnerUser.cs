using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging.Abstractions;
using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

[Table("InnerUser")]
public class InnerUser
{
    public int InnerUserId { get; set; }
    public long TelegramUserId { get; set; }
    public string OriginalFullName { get; set; } = null!;
    public string? Username { get; set; }
    public bool IsInCrewMode { get; set; }

    public int? RoleId { get; set; }
    public RegularUserRole? Role { get; set; }

    public int ContactId { get; set; }
    public InnerContact? Contact { get; set; }

    public InnerUser() { }

    public InnerUser(User user)
    {
        TelegramUserId = user.Id;
        OriginalFullName = user.LastName is null ? user.FirstName : $"{user.FirstName} {user.LastName}";
        Username = user.Username;
    }
}