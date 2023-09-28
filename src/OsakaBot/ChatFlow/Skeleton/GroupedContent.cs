using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("GroupedContent")]
public class GroupedContent
{
    public int GroupedContentId { get; private set; }
    public int Position { get; private set; }

    public int InnerMessageId { get; private set; }
    public InnerMessage InnerMessage { get; private set; } = null!;

    public int GroupId { get; private set; }
    public Group Group { get; private set; } = null!;

    public GroupedContent(int position, InnerMessage content)
    {
        Position = position;
        InnerMessage = content;
    }

    private GroupedContent() { }
}