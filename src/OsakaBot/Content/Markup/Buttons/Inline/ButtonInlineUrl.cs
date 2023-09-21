using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Inline;

public class ButtonInlineUrl : ButtonInline
{
    public string Url { get; private set; } = null!;

    protected ButtonInlineUrl() { }

    public ButtonInlineUrl(
        string url,
        Text text,
        byte rowPriority,
        byte columnPriority,
        ICollection<RegularUserRole>? roleVisibility = null,
        string? phraseVisibility = null)
        : base(text, rowPriority, columnPriority, null, null, roleVisibility, phraseVisibility)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        {
            Url = uriResult.AbsolutePath;
            Type = ButtonType.InlineUrl;
        }
        else
            throw new ArgumentException("Submitted URL is not  a URL");
    }

    public override async ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg) => !CheckVisibility(arg)
            ? null
            : new(InlineKeyboardButton.WithUrl(
                await Text.ToStringAsync(arg.User, arg.TextDispatcher, true),
                Url));
}