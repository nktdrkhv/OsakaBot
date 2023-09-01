using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Keyboards;

public class InlineButton : ButtonBase
{
    public string? Url { get; set; }
    [NotMapped] public string? CallbackData { get; set; }
}