using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

public class ButtonReply : ButtonBase
{
    public bool RequestContact { get; set; }
    public bool RequestLocation { get; set; }

    public ButtonReply()
    {
        Type = ButtonType.Reply;
    }

    public override ButtonMarkup BuildButton(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}