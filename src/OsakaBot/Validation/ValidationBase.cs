using Microsoft.Extensions.Options;

namespace Osaka.Bot.Validation;

public abstract class ValidationBase
{
    public int ValidationBaseId { get; set; }
    public int PriorityGroup { get; set; }
    //public abstract bool Validate();
}