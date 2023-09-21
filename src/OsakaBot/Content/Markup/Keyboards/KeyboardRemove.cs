using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Keyboards;

public class KeyboardRemove : KeyboardBase
{
    public KeyboardRemove() => Type = KeyboardType.Remove;

    public override ValueTask<KeyboardMarkup> BuildMarkupAsync(CompositeArgument arg) =>
        ValueTask.FromResult<KeyboardMarkup>(new(new ReplyKeyboardRemove(), Array.Empty<ActiveKeyboardTrigger>()));
}