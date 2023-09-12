using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.UserSpecific;

[Table("CrewMember")]
public class CrewMember
{
    public int CrewMemberId { get; set; }
    public CrewMemberType Role { get; set; }

    public int? RegularUserId { get; set; }
    public InnerUser? RegularUser { get; set; }

    public ICollection<Report> Responsobilities = null!;
}