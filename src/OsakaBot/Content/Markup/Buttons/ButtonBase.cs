using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

[Table("Button")]
public abstract class ButtonBase : IRoleVisibility, IMetaMark
{
    [Key] public int ButtonId { get; set; }
    public ButtonType Type { get; set; } = ButtonType.None;

    public byte RowPriority { get; set; }
    public byte ColumnPriority { get; set; }

    public int TextId { get; set; }
    public int? TriggerId { get; set; }
    public Text Text { get; set; } = null!;
    public Trigger? Trigger { get; set; }

    public int KeyboardId { get; set; }
    public KeyboardBase Keyboard { get; set; } = null!;

    public string? MetaMark { get; set; }
    public ICollection<RegularUserRole>? RoleVisibility { get; set; }
    public string? PhraseVisibility { get; set; }

    public abstract ButtonMarkup BuildButton(CompositeArgument arg);
}