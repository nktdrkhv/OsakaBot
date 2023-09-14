using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardInlineDayPicker : KeyboardInline
{
    public int? CommonTriggerId { get; set; }
    public Trigger? CommonTrigger { get; set; }

    public KeyboardInlineDayPicker()
    {
        Type = KeyboardType.InlineDayPicker;
    }

    // public KeyboardInlineDayPicker(DateTime? today)
    // {
    //     var date = today ?? DateTime.Today;
    // }

    public override KeyboardMarkup BuildMarkup(CompositeArgument arg)
    {
        throw new NotImplementedException();
    }
}