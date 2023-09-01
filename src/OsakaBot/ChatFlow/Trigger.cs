namespace Osaka.Bot.ChatFlow;

public class Trigger
{
    public int TriggerId { get; set; }
    public bool AllowOutOfScope { get; set; } = false;
    public ICollection<EffectBase> Effects { get; set; } = null!;
}