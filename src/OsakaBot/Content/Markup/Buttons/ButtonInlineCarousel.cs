using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

public class ButtonInlineCarousel : ButtonInline
{
    [NotMapped] public static readonly string Identifier = "cc";
    [NotMapped] public static readonly string Rightwards = "r";

    public ButtonInlineCarousel()
    {
        Type = ButtonType.InlineCarousel;
    }

    // public ButtonInlineCarousel(int currentPosition)
    // {

    // }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}