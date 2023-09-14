namespace Osaka.Bot.Validation;

public abstract class RegexValidatorBase : ValidatorBase
{
    public bool DoFormatting = true;
    public abstract override bool Validate(InnerMessage message);
}