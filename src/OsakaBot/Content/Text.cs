namespace Osaka.Bot.Content;

public class Text
{
    public int TextId { get; set; }
    public string? TextLabel { get; set; }
    public string OriginalText { get; set; } = null!;
    public string? PreparedText { get; set; }
    public ICollection<TextSetterBase>? Surrogates { get; set; }
}