using System.Security.Cryptography;
using Telegram.Bot.Types;

namespace Osaka.Bot.Content.Textable;

public class Text
{
    public int TextId { get; set; }

    public string OriginalText { get; set; } = null!;
    public ICollection<MessageEntity>? OriginalEntities { get; set; }

    public string? PlainText { get; set; }
    public string? PreparedText { get; set; }
    public ICollection<TextSetterBase>? Surrogates { get; set; }

    public Text() { }
    public Text(string text) => OriginalText = text.Trim();

    public async ValueTask<string> ToStringAsync(InnerUser user, ITextSetterDispatcher dispatcher, bool isButtonTarger)
    {
        if (Surrogates != null && Surrogates.Count > 0)
        {
            var reals = new List<string>();
            foreach (var surrogate in Surrogates.OrderBy(s => s.Position))
            {
                surrogate.User = user;
                reals.Add(await dispatcher.ResolveAsync(surrogate!));
            }

            if (isButtonTarger && PlainText != null)
                return string.Format(PlainText, reals.ToArray());
            else if (PreparedText != null)
                return string.Format(PreparedText!, reals.ToArray());
            else
                return string.Empty;
        }
        else
            return OriginalText;
    }
}