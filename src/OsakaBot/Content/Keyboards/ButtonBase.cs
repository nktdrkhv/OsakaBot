using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Keyboards;

[Table("Button")]
public abstract class ButtonBase
{
    [Key] public int ButtonId { get; set; }
    public Text Text { get; set; } = null!;
    public Trigger? Trigger { get; set; }
}