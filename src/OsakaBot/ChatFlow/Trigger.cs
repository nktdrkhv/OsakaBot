using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow;

[Table("Trigger")]
public sealed class Trigger
{
    public int TriggerId { get; private set; }
    public bool AllowOutOfScope { get; private set; } = false;
    public ICollection<EffectBase> Effects { get; private set; } = null!;

    public Trigger(bool allowOutOfScope, params EffectBase[] effects) => (AllowOutOfScope, Effects) = (allowOutOfScope, effects);
    private Trigger() { }
}