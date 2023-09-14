using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

public record ButtonMarkup(IKeyboardButton Button, ActiveKeyboardTrigger? Trigger = null);