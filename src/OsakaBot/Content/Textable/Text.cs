using System.Security.Cryptography;

namespace Osaka.Bot.Content.Textable;

public class Text
{
    public int TextId { get; set; }
    public string? TextLabel { get; set; }
    public string OriginalText { get; set; } = null!;
    public string? PlainText { get; set; }
    public string? PreparedText { get; set; }
    public ICollection<TextSetterBase>? Surrogates { get; set; }

    public Text(string text) => OriginalText = text;
}