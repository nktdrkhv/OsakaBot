using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class KeyboardInlineDayPicker : KeyboardInline
{
    public Trigger? CommonTrigger { get; set; }

    // public KeyboardInlineDayPicker(DateTime? today)
    // {
    //     var date = today ?? DateTime.Today;
    // }
    public override KeyboardMarkup BuildMarkup(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}