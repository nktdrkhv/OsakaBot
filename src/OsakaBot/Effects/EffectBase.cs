using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Effects;

[Table("Effect")]
public abstract class EffectBase : ITitled
{
    [Key] public int EffectId { get; set; }
    public EffectType Type { get; set; }
    public byte Order { get; set; }
    public string? Title { get; set; }
    [NotMapped] public InnerUser User { get; set; } = null!;

    public abstract void SetArguments(string[] args);
}