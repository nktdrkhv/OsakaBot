using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

[Table("Button")]
public abstract class ButtonBase : IRoleVisibility, IMetaMark
{
    [Key] public int ButtonId { get; set; }

    public byte RowPriority { get; set; }
    public byte ColumnPriority { get; set; }

    public int TextId { get; set; }
    public int? TriggerId { get; set; }
    public Text Text { get; set; } = null!;
    public Trigger? Trigger { get; set; }

    public string? MetaMark { get; set; }
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    public abstract ButtonMarkup BuildButton(CompositeArgument arg);
}