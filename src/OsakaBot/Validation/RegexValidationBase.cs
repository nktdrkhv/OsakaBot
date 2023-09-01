using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace Osaka.Bot.Validation;

public abstract class RegexValidatorBase : ValidatorBase
{
    public bool DoFormatting = false;
    public abstract override bool Validate(InnerMessage message);
}