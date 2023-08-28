using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Effects;

public abstract class EffectBase
{
    [Key]
    public int EffectId { get; set; }
    public int Order { get; set; }
    public string? Title { get; set; }
    [NotMapped] public InnerUser User { get; set; } = null!;
}