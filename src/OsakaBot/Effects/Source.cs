using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Effects;

[Table("Source")]
public class Source : ILabeled
{
    public int SourceId { get; private set; }
    public SourceType Type { get; private set; } = SourceType.None;

    public int? KeyboardId { get; private set; }
    public KeyboardBase? Keyboard { get; private set; }

    public int? ContentId { get; private set; }
    public InnerMessage? Content { get; private set; }

    public int? PostId { get; private set; }
    public Post? Post { get; private set; }

    public int? MediaId { get; private set; }
    public Media? Media { get; private set; }

    public string? Label { get; private set; }

    public Source(KeyboardBase keyboard)
    {
        Type = SourceType.Keyboard;
        Keyboard = keyboard;
    }

    public Source(InnerMessage content)
    {
        Type = SourceType.Content;
        Content = content;
    }

    public Source(Post post)
    {
        Type = SourceType.Post;
        Post = post;
    }

    public Source(Media media, string label)
    {
        Type = SourceType.LabeledMedia;
        Media = media;
        Label = label;
    }

    public Source(string label)
    {
        Type = SourceType.Label;
        Label = label;
    }

    protected Source() { }
}