using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardRemove : KeyboardBase
{
    public KeyboardRemove()
    {
        Type = KeyboardType.Remove;
    }

    public override KeyboardMarkup BuildMarkup(CompositeArgument arg) => new(new ReplyKeyboardRemove(), Array.Empty<ActiveKeyboardTrigger>());
}