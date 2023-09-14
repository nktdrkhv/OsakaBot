using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Validation;

[Table("Validator")]
public abstract class ValidatorBase
{
    [Key] public int ValidatorId { get; set; }
    public ValidatorType Type { get; set; }
    public byte PriorityGroup { get; set; }
    public bool Invert { get; set; }
    public ICollection<ChatScope>? IncludedIn { get; set; }
    public abstract bool Validate(InnerMessage message);
}