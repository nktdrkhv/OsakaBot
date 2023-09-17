using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("Group")]
public class Group
{
    public int GroupId { get; set; }
    public GroupType Type { get; set; }

    public ICollection<GroupedContent>? Contents { get; set; }
}