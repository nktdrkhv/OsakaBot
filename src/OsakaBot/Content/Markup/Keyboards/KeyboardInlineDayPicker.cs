using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater.Helpers;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardInlineDayPicker : KeyboardInline
{
    public int? CommonTriggerId { get; set; }
    public Trigger? CommonTrigger { get; set; }

    public KeyboardInlineDayPicker() => Type = KeyboardType.InlineDayPicker;

    public override KeyboardMarkup BuildMarkup(CompositeArgument arg)
    {
        // todo: get first line from connected buttons
        var grid = new GridCollection<InlineKeyboardButton>(7);
        var today = DateTime.Now;
        var convDay = (int)today.DayOfWeek - 1;
        double currentDayNumber = convDay < 0 ? 6 : convDay;
        var code = CommonTriggerId != null ? arg.Hasher.Encode(arg.InnerUserId, CommonTriggerId.Value) : "#";
        grid
            .AddItem(InlineKeyboardButton.WithCallbackData("ПН"))
            .AddItem(InlineKeyboardButton.WithCallbackData("ВТ"))
            .AddItem(InlineKeyboardButton.WithCallbackData("СР"))
            .AddItem(InlineKeyboardButton.WithCallbackData("ЧТ"))
            .AddItem(InlineKeyboardButton.WithCallbackData("ПТ"))
            .AddItem(InlineKeyboardButton.WithCallbackData("СБ"))
            .AddItem(InlineKeyboardButton.WithCallbackData("ВС"));
        for (int i = 0; i < 21; i++)
            grid.Add(DayButton(today.AddDays(i - currentDayNumber), code));
        return new(new InlineKeyboardMarkup(grid.Items), Array.Empty<ActiveKeyboardTrigger>());
    }

    private static InlineKeyboardButton DayButton(DateTime date, string code)
    {
        string day = date.Day == DateTime.Now.Day ? $"||{date.Day}||" : date.Day.ToString();
        return InlineKeyboardButton.WithCallbackData(day, $"i:{code}:{date.ToShortDateString()}");
    }
}