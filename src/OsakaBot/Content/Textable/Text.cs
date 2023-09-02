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
}