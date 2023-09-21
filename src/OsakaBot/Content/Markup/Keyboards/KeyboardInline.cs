using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater.Helpers;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardInline : KeyboardBase
{
    protected KeyboardInline() { }

    public KeyboardInline(string? title, params ButtonInline[] buttons)
    {
        Type = KeyboardType.Inline;
        Title = title;
        Buttons = buttons;
    }

    public override async ValueTask<KeyboardMarkup> BuildMarkupAsync(CompositeArgument arg)
    {
        var grid = new GridCollection<InlineKeyboardButton>();
        var akts = new List<ActiveKeyboardTrigger>();
        await FillAsync(arg, grid, akts);
        var markup = new InlineKeyboardMarkup(grid.Items);
        return new KeyboardMarkup(markup, akts);
    }
}