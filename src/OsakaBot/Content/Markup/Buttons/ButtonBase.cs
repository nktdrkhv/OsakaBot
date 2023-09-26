using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons;

[Table("Button")]
public abstract class ButtonBase : IRoleVisibility, IMetaMark, IMarkupBuilder<ButtonMarkup?>
{
    [Key] public int ButtonId { get; private set; }
    public ButtonType Type { get; protected set; } = ButtonType.None;

    public byte RowPriority { get; protected set; }
    public byte ColumnPriority { get; protected set; }

    public int TextId { get; private set; }
    public int? TriggerId { get; private set; }
    public Text Text { get; protected set; } = null!;
    public Trigger? Trigger { get; protected set; }

    public int KeyboardId { get; private set; }
    public KeyboardBase Keyboard { get; private set; } = null!;

    public string? MetaMark { get; protected set; }
    public ICollection<UserRole>? RoleVisibility { get; protected set; }
    public string? PhraseVisibility { get; protected set; }

    protected ButtonBase() { }

    protected ButtonBase(
        Text text,
        byte rowPriority,
        byte columnPriority,
        Trigger? trigger = null,
        string? metaMark = null,
        ICollection<UserRole>? roleVisibility = null,
        string? phraseVisibility = null)
    {
        Text = text;
        RowPriority = rowPriority;
        ColumnPriority = columnPriority;
        Trigger = trigger;
        MetaMark = metaMark;
        RoleVisibility = roleVisibility;
        PhraseVisibility = phraseVisibility;
    }

    protected bool CheckVisibility(CompositeArgument arg) =>
        RoleVisibility != null && RoleVisibility.Any(rv => rv.UserRoleId == arg.RoleId)
        || PhraseVisibility != null && PhraseVisibility == arg.UserPhrase;

    public abstract ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg);
}