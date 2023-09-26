using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Effects;

[Table("Effect")]
public abstract class EffectBase
{
    [Key] public int EffectId { get; private set; }
    public EffectType Type { get; private set; } = EffectType.None;
    public byte Order { get; private set; }
    [NotMapped] public InnerUser User { get; set; } = null!;

    protected EffectBase(EffectType type, byte order) => (Type, Order) = (type, order);
    protected EffectBase() { }

    public abstract void SetArguments(string[] args);
}