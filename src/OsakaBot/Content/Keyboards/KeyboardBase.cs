using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Keyboards;

[Table("Keyboard")]
public abstract class KeyboardBase
{
    [Key] public int KeyboardId { get; set; }
    public string? Title { get; set; }
    public ICollection<ButtonBase> Buttons { get; set; } = null!;
}
