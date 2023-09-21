using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Inline;

public abstract class ButtonInline : ButtonBase
{
    [NotMapped] public const string SimplePrefix = "s";
    [NotMapped] public const string InsidePrefix = "i";
    [NotMapped] public const string DynamicPrefix = "d";
    [NotMapped] public string? CallbackData { get; protected set; }

    protected ButtonInline() { }

    protected ButtonInline(
        Text text,
        byte rowPriority,
        byte columnPriority,
        Trigger? trigger,
        string? metaMark = null,
        ICollection<RegularUserRole>? roleVisibility = null,
        string? phraseVisibility = null)
        : base(text, rowPriority, columnPriority, trigger, metaMark, roleVisibility, phraseVisibility)
        => Type = ButtonType.Inline;

    public abstract override ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg);
}