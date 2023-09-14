using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

public class ButtonInlineEncoded : ButtonInline
{
    public ButtonInlineEncoded()
    {
        Type = ButtonType.InlineEncoded;
    }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}