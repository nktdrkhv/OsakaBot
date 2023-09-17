namespace Osaka.Bot.Effects;

public class Target : ILabeled
{
    public TargetType Type { get; set; } = TargetType.None;

    public string? Label { get; set; }

    public int? ContentId { get; set; }
    public InnerMessage? Content { get; set; }

    public int? PostId { get; set; }
    public Post? Post { get; set; }

    public Target() { }

    public Target(string label)
    {
        Type = TargetType.Labeled;
        Label = label;
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
}