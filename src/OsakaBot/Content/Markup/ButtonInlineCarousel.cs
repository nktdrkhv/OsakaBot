using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class ButtonInlineCarousel : ButtonInline
{
    [NotMapped] public static readonly string Identifier = "cc";

    // public ButtonInlineCarousel(int currentPosition)
    // {

    // }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}