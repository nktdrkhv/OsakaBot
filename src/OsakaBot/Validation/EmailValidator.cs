namespace Osaka.Bot.Validation;

public class EmailValidator : RegexValidatorBase
{
    public EmailValidator() => Type = ValidatorType.Email;

    public override bool Validate(InnerMessage message)
    {
        throw new NotImplementedException();
    }
}