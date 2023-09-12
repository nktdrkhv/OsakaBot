using Sqids;

namespace Osaka.Bot.Content.Markup;

public record CompositeArgument
{
    public DateTime Time { get; set; } = DateTime.Today;
    public SqidsEncoder Hasher { get; set; } = null!;
    public ITextSetterDispatcher TextDispatcher { get; set; } = null!;
    public RegularUserRole RegularUserRole { get; set; } = null!;
    public string? UserPhrase { get; set; }
}