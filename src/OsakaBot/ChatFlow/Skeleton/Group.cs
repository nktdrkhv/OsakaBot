using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("Group")]
public class Group : ITitled
{
    public int GroupId { get; set; }
    public GroupType Type { get; set; }
    public string? Title { get; set; }

    public ICollection<GroupedContent>? Contents { get; set; }
}