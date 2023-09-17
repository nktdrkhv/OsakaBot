namespace Osaka.Bot.Validation;

public class NameValidator : RegexValidatorBase
{
    public NameValidator() => Type = ValidatorType.Name;

    public override bool Validate(InnerMessage message)
    {
        throw new NotImplementedException();
    }

    public override bool Validate(string text)
    {
        throw new NotImplementedException();
    }
}