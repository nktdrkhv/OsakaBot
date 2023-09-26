using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Inline;

public class ButtonInlineEncoded : ButtonInline
{
    protected ButtonInlineEncoded() { }

    public ButtonInlineEncoded(
        Text text,
        byte rowPriority,
        byte columnPriority,
        Trigger trigger,
        string? metaMark = null,
        ICollection<UserRole>? roleVisibility = null,
        string? phraseVisibility = null)
    : base(text, rowPriority, columnPriority, trigger, metaMark, roleVisibility, phraseVisibility)
    => Type = ButtonType.InlineEncoded;

    public async override ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg)
    {
        if (!CheckVisibility(arg)) return null;
        var code = arg.Hasher.Encode(arg.User.InnerUserId, TriggerId!.Value);
        CallbackData = $"{SimplePrefix}:{code}";
        var text = await Text.ToStringAsync(arg.User, arg.TextDispatcher, true);
        var button = InlineKeyboardButton.WithCallbackData(text, CallbackData);
        var akt = new ActiveKeyboardTrigger(code, Trigger!);
        return new(button, akt);
    }
}