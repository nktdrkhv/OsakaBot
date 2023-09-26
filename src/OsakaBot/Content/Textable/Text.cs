using System.Security.Cryptography;
using Telegram.Bot.Types;

namespace Osaka.Bot.Content.Textable;

public class Text
{
    public int TextId { get; private set; }

    /// <summary>
    /// Original text itself, without any changes
    /// </summary>
    public string OriginalText { get; set; } = string.Empty;
    /// <summary>
    /// Same as original, but with HTML formatting
    /// </summary>
    public string? OriginalPreparedText { get; set; }
    public ICollection<MessageEntity>? OriginalEntities { get; set; }

    /// <summary>
    /// Original text, with prepared {}
    /// </summary>
    public string? PlainText { get; set; }
    /// <summary>
    /// Original text, with prepared {} and HTML formatting
    /// </summary>
    public string? PreparedText { get; set; }
    public ICollection<TextSetterBase>? Surrogates { get; set; }

    public Text(string text, MessageEntity[]? entities)
    {
        // todo: transformation
        OriginalText = text.Trim();
        OriginalEntities = entities;
    }
    public Text() { }

    // public static Text ForButton(string text, params TextSetterBase[] setters)
    // {

    // }

    public async ValueTask<string> ToStringAsync(InnerUser user, ITextSetterDispatcher dispatcher, bool isPlain)
    {
        if (Surrogates!.Any())
        {
            var reals = new List<string>();
            foreach (var surrogate in Surrogates!.OrderBy(s => s.Position))
            {
                surrogate.User = user;
                reals.Add(await dispatcher.ResolveAsync(surrogate!));
            }

            return isPlain && PlainText != null
                ? string.Format(PlainText, reals.ToArray())
                : PreparedText != null ? string.Format(PreparedText!, reals.ToArray()) : string.Empty;
        }
        else
            return isPlain && OriginalPreparedText != null ? OriginalPreparedText : OriginalText;
    }
}