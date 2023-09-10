using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Content.Markup;

[Table("Keyboard")]
public abstract class KeyboardBase : ILabeled, ITitled
{
    [Key] public int KeyboardId { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }
    public KeyboardType Type { get; set; } = KeyboardType.None;
    public ICollection<ButtonBase>? Buttons { get; set; }

    public abstract KeyboardMarkup BuildMarkup(CompositeArgument arg);
}