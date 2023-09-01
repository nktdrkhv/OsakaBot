namespace Osaka.Bot.Content.Keyboards;

public class KeyboardReply : KeyboardBase
{
    public string? Placeholder { get; set; }
    public bool Resize { get; set; }
    public bool Persistent { get; set; }
    public bool OneTime { get; set; }
}