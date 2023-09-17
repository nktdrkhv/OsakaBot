using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Keyboards;

public record KeyboardMarkup(IReplyMarkup Markup, ICollection<ActiveKeyboardTrigger> Triggers);