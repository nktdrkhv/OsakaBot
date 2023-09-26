using System.Security.Authentication.ExtendedProtection;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Inline;

public class ButtonInlineMention : ButtonInline
{
    public int TelegramUserId { get; private set; }

    protected ButtonInlineMention() { }

    public ButtonInlineMention(
        int telegramUserId,
        Text text,
        byte rowPriority,
        byte columnPriority,
        ICollection<UserRole>? roleVisibility = null,
        string? phraseVisibility = null)
         : base(text, rowPriority, columnPriority, null, null, roleVisibility, phraseVisibility)
    {
        Type = ButtonType.InlineMention;
        TelegramUserId = telegramUserId;
    }

    public override async ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg) => !CheckVisibility(arg)
            ? null
            : new(InlineKeyboardButton.WithUrl(
                await Text.ToStringAsync(arg.User, arg.TextDispatcher, true),
                $"tg://user?id={TelegramUserId}"));
}