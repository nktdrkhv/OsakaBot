using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public record KeyboardMarkup(IReplyMarkup Markup, ICollection<ActiveKeyboardTrigger>? Triggers = null);