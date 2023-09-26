using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.Versioning;

namespace Osaka.Bot.Effects;

[Table("Table")]
public class Target : ILabeled
{
    public int TargetId { get; protected set; }
    public TargetType Type { get; protected set; } = TargetType.None;

    public string? Label { get; private set; }
    public int? MessageId { get; private set; }

    public int? ContentId { get; private set; }
    public InnerMessage? Content { get; private set; }

    public int? PostId { get; private set; }
    public Post? Post { get; private set; }

    public OrphanType? Orphan { get; private set; }

    public Target(string label)
    {
        Type = TargetType.Labeled;
        Label = label;
    }

    public Target(OrphanType orphan)
    {
        Type = TargetType.Orphan;
        Orphan = orphan;
    }

    public Target(int messageId)
    {
        Type = TargetType.TelegramMessage;
        MessageId = messageId;
    }

    public Target(InnerMessage content)
    {
        Type = TargetType.Content;
        Content = content;
    }

    public Target(Post post)
    {
        Type = TargetType.Post;
        Post = post;
    }

    protected Target() { }
}