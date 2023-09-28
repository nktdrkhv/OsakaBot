using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup.Buttons.Inline;

public class ButtonInlineCarousel : ButtonInline
{
    [NotMapped] public const string Identifier = "cc";
    [NotMapped] public const string Rightward = "r";
    [NotMapped] public const string Leftward = "l";

    //public int CurrentPosition { get; private set; } = 0;
    public bool IsMovingRightward { get; private set; } = true;

    protected ButtonInlineCarousel() { }

    public ButtonInlineCarousel(
        int currentPosition,
        bool isMovingRightward,
        Text text,
        byte rowPriority,
        byte columnPriority,
        Trigger trigger,
        string? metaMark = null,
        ICollection<UserRole>? roleVisibility = null,
        string? phraseVisibility = null)
        : base(text, rowPriority, columnPriority, trigger, metaMark, roleVisibility, phraseVisibility)
    {
        Type = ButtonType.InlineCarousel;
        //CurrentPosition = currentPosition;
        IsMovingRightward = isMovingRightward;
    }

    public override async ValueTask<ButtonMarkup?> BuildMarkupAsync(CompositeArgument arg)
    {
        if (!CheckVisibility(arg)) return null;
        var code = arg.Hasher.Encode(arg.User.InnerUserId, TriggerId!.Value);
        var direction = IsMovingRightward ? Rightward : Leftward;
        CallbackData = $"{DynamicPrefix}:{code}:{Identifier}:{direction}"; //$"{DynamicPrefix}:{code}:{Identifier}:{CurrentPosition}:{direction}"
        var text = await Text.ToStringAsync(arg.User, arg.TextDispatcher, true);
        if (string.IsNullOrWhiteSpace(text))
            return null;
        var button = InlineKeyboardButton.WithCallbackData(text, CallbackData);
        var akt = new ActiveKeyboardTrigger(code, Trigger!);
        return new(button, akt);
    }
}