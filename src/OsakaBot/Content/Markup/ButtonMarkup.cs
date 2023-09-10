using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public record ButtonMarkup(IKeyboardButton Button, ActiveKeyboardTrigger? Trigger = null);