using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

public class KeyboardRemove : KeyboardBase
{
    public override KeyboardMarkup BuildMarkup(CompositeArgument arg) => new(new ReplyKeyboardRemove());
}