using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardInline : KeyboardBase
{
    public KeyboardInline()
    {
        Type = KeyboardType.Inline;
    }

    public override KeyboardMarkup BuildMarkup(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}