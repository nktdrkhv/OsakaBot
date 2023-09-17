namespace Osaka.Bot.Effects;

public class Source
{
    public SourceType Type { get; set; } = SourceType.None;

    public int? KeyboardId { get; set; }
    public KeyboardBase? Keyboard { get; set; }

    public int? ContentId { get; set; }
    public InnerMessage? Content { get; set; }

    public int? PostId { get; set; }
    public Post? Post { get; set; }

    public Source() { }

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
}