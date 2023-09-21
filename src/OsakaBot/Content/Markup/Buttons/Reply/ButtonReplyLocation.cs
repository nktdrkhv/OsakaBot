using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Reply;

public class ButtonReplyLocation : ButtonReply
{
    protected ButtonReplyLocation() { }

    public ButtonReplyLocation(
        Text text,
        byte rowPriority,
        byte columnPriority,
        ICollection<RegularUserRole>? roleVisibility = null,
        string? phraseVisibility = null)
        : base(text, rowPriority, columnPriority, null, null, roleVisibility, phraseVisibility)
        => Type = ButtonType.ReplyContact;

    public async override ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg)
    {
        if (!CheckVisibility(arg)) return null;
        var text = await Text.ToStringAsync(arg.User, arg.TextDispatcher, true);
        var button = KeyboardButton.WithRequestLocation(text);
        return new(button, null);
    }
}