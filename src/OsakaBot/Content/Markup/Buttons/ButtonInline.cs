using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

public class ButtonInline : ButtonBase
{
    public string? Url { get; set; }
    [NotMapped] public string? CallbackData { get; set; }

    public ButtonInline()
    {
        Type = ButtonType.Inline;
    }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}