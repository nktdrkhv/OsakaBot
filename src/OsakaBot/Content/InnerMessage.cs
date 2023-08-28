using Telegram.Bot.Types;

namespace Osaka.Bot.Content;

public class InnerMessage : MessageBase
{
    public InnerMessage(int causeMessageId, Text textItself, bool buttonOrigin = false)
    {
        CauseMessageId = causeMessageId;
        Text = textItself;
        Type = buttonOrigin ? InnerMessageType.TextFromButton : InnerMessageType.Text;
    }

    public InnerMessage(Message message)
    {

    }
}