using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Textable;

[Table("TextSetter")]
public abstract class TextSetterBase
{
    [Key] public int TextSetterId { get; set; }
    public TextSetterType Type { get; set; }
    [NotMapped] public InnerUser User { get; set; } = null!;
    public int Position { get; set; }
}