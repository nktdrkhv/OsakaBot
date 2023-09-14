using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Content.Textable;

[Table("TextSetter")]
public abstract class TextSetterBase
{
    [Key] public int TextSetterId { get; set; }
    public TextSetterType Type { get; set; }

    public int Position { get; set; }

    public int TextId { get; set; }
    public Text Text { get; set; } = null!;
}