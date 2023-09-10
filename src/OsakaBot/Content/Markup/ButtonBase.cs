using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

[Table("Button")]
public abstract class ButtonBase : IRoleVisibility
{
    [Key] public int ButtonId { get; set; }
    public Text Text { get; set; } = null!;
    public Trigger? Trigger { get; set; }
    public byte RowPriority { get; set; }
    public byte ColumnPriority { get; set; }
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    public abstract ButtonMarkup BuildButton(CompositeArgument arg);
}