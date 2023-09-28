using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.Skeleton;

[Table("Group")]
public class Group : ITitled
{
    public int GroupId { get; private set; }
    public GroupType Type { get; private set; }
    public string? Title { get; private set; }

    public ICollection<GroupedContent>? Contents { get; set; }

    public Group(string title, GroupType type, params GroupedContent[] contents)
    {
        Title = title;
        Type = type;
        if (contents.Length > 0)
            Contents = contents;
        else
            throw new ArgumentNullException(paramName: $"{nameof(contents)}", $"Data should be passed");
    }

    private Group() { }
}