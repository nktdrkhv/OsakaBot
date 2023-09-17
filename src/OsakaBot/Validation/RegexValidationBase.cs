namespace Osaka.Bot.Validation;

public abstract class RegexValidatorBase : ValidatorBase
{
    public bool DoFormatting = true;
    public override bool Validate(InnerMessage message) => message.Text?.OriginalText is string text && Validate(text);
    public abstract override bool Validate(string text);
}