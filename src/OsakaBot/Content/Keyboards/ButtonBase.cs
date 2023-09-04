using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Keyboards;

[Table("Button")]
public abstract class ButtonBase : IVisible
{
    [Key] public int ButtonId { get; set; }
    public Text Text { get; set; } = null!;
    public Trigger? Trigger { get; set; }
    public byte RowPriority { get; set; }
    public byte ColumnPriority { get; set; }
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }
}