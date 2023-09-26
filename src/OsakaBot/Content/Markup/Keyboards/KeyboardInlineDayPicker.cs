using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater.Helpers;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardInlineDayPicker : KeyboardInline
{
    public KeyboardInlineDayPicker() => Type = KeyboardType.InlineDayPicker;

    public override ValueTask<KeyboardMarkup> BuildMarkupAsync(CompositeArgument arg)
    {
        // todo: get first line from connected buttons
        var grid = new GridCollection<InlineKeyboardButton>(7);
        var today = DateTime.Now;
        var convDay = (int)today.DayOfWeek - 1;
        double currentDayNumber = convDay < 0 ? 6 : convDay;
        var code = CommonTriggerId != null ? arg.Hasher.Encode(arg.User.InnerUserId, CommonTriggerId.Value) : "#";
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
        var markup = new InlineKeyboardMarkup(grid.Items);
        return ValueTask.FromResult<KeyboardMarkup>(new(markup, Array.Empty<ActiveKeyboardTrigger>()));
    }

    private static InlineKeyboardButton DayButton(DateTime date, string code)
    {
        string day = date.Day == DateTime.Now.Day ? $"||{date.Day}||" : date.Day.ToString();
        return InlineKeyboardButton.WithCallbackData(day, $"i:{code}:{date.ToShortDateString()}");
    }
}