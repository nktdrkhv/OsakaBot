using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Validation;

[Table("Validator")]
public abstract class ValidatorBase
{
    [Column("ValidatorId")]
    public int ValidationBaseId { get; set; }
    public byte PriorityGroup { get; set; }
    public bool Invert { get; set; }
    public abstract bool Validate(InnerMessage message);
}