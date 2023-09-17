using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("GroupedContent")]
public class GroupedContent
{
    public int GroupedContentId { get; set; }
    public int Position { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; } = null!;

    public int InnerMessageId { get; set; }
    public InnerMessage InnerMessage { get; set; } = null!;
}