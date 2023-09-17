using Sqids;

namespace Osaka.Bot.Content.Markup;

public record CompositeArgument
{
    public int InnerUserId { get; set; }
    public DateTime Time { get; set; } = DateTime.Today;
    public SqidsEncoder Hasher { get; set; } = null!;
    public ITextSetterDispatcher TextDispatcher { get; set; } = null!;
    public int RoleId { get; set; }
    public string? UserPhrase { get; set; }
}