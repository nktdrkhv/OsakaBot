using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class KeyboardReply : KeyboardBase
{
    public string? Placeholder { get; set; }
    public bool Resize { get; set; }
    public bool Persistent { get; set; }
    public bool OneTime { get; set; }

    public override KeyboardMarkup BuildMarkup(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}