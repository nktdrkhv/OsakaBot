using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class ButtonReply : ButtonBase
{
    public bool RequestContact { get; set; }
    public bool RequestLocation { get; set; }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}