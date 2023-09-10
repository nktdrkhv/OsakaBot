using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class ButtonInline : ButtonBase
{
    public string? Url { get; set; }
    [NotMapped] public string? CallbackData { get; set; }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}