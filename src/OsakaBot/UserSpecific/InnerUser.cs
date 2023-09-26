using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging.Abstractions;
using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

[Table("InnerUser")]
public class InnerUser
{
    public int InnerUserId { get; private set; }
    public long TelegramUserId { get; private set; }
    public string OriginalFullName { get; set; } = null!;
    public string? Username { get; set; }

    public int? RoleId { get; set; }
    public UserRole? Role { get; set; }

    public int ContactId { get; set; }
    public InnerContact? Contact { get; set; }

    public bool IsCrew { get; set; } = false;
    public bool SelfBlocked { get; set; } = false;
    public bool Banned { get; set; } = false;

    public InnerUser(User user)
    {
        TelegramUserId = user.Id;
        OriginalFullName = string.IsNullOrEmpty(user.LastName) ? user.FirstName : $"{user.FirstName} {user.LastName}";
        Username = user.Username;
    }

    protected InnerUser() { }
}