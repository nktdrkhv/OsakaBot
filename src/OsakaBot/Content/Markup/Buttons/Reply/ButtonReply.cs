using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Reply;

public class ButtonReply : ButtonBase
{
    public ButtonReply(
        Text text,
        byte rowPriority = 0,
        byte columnPriority = 0,
        Trigger? trigger = null,
        string? metaMark = null,
        ICollection<UserRole>? roleVisibility = null,
        string? phraseVisibility = null)
        : base(text, rowPriority, columnPriority, trigger, metaMark, roleVisibility, phraseVisibility)
        => Type = ButtonType.Reply;

    protected ButtonReply() { }

    public async override ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg)
    {
        if (!CheckVisibility(arg)) return null;
        var text = await Text.ToStringAsync(arg.User, arg.TextDispatcher, true);
        var button = new KeyboardButton(text);
        var akt = Trigger != null ? new ActiveKeyboardTrigger(text, Trigger) : null;
        return new(button, akt);
    }
}