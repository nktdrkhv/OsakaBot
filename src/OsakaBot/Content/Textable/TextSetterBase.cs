using System.ComponentModel.DataAnnotations;

namespace Osaka.Bot.Content.Textable;

public abstract class TextSetterBase
{
    [Key]
    public int TextSetterId { get; set; }
}