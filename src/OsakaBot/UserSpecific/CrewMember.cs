using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.UserSpecific;

[Table("CrewMember")]
public class CrewMember
{
    public int CrewMemberId { get; set; }
    public CrewMemberType Role { get; set; }
    public CrewMemberType CurrentMode { get; set; } = CrewMemberType.None;

    public int CustomContactId { get; set; }
    public InnerContact CustomContact { get; set; } = null!;

    public int? MemberId { get; set; }
    public InnerUser? Member { get; set; }

    public string? AuthorizationCode { get; set; }
    public bool IsDeactivated { get; set; } = false;

    public ICollection<Report> Responsobilities = null!;
}