using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow;

[Table("Trigger")]
public class Trigger
{
    public int TriggerId { get; set; }
    public bool AllowOutOfScope { get; set; } = false;
    public ICollection<EffectBase> Effects { get; set; } = null!;

    public Trigger() { }
    public Trigger(params EffectBase[] effects) => Effects = effects;
}