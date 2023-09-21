using Telegram.Bot.Types.ReplyMarkups;
using TelegramUpdater.Helpers;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardReply : KeyboardBase
{
    public string? Placeholder { get; set; }
    public bool HasResize { get; set; }
    public bool IsPersistent { get; set; }
    public bool IsOneTime { get; set; }

    protected KeyboardReply() { }

    public KeyboardReply(string? title, string? placeholder, bool hasResize, bool isPersistent, bool isOneTime, params ButtonReply[] buttons)
    {
        Type = KeyboardType.Reply;
        Title = title;
        Placeholder = placeholder;
        HasResize = hasResize;
        IsPersistent = isPersistent;
        IsOneTime = isOneTime;
        Buttons = buttons;
    }

    public override async ValueTask<KeyboardMarkup> BuildMarkupAsync(CompositeArgument arg)
    {
        var grid = new GridCollection<KeyboardButton>();
        var akts = new List<ActiveKeyboardTrigger>();
        await FillAsync(arg, grid, akts);
        var markup = new ReplyKeyboardMarkup(grid.Items)
        {
            InputFieldPlaceholder = Placeholder,
            ResizeKeyboard = HasResize,
            IsPersistent = IsPersistent,
            OneTimeKeyboard = IsOneTime
        };
        return new KeyboardMarkup(markup, akts);
    }
}