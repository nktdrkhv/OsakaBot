namespace Osaka.Bot.Validation;

public interface IValidationService
{
    ValueTask<bool> ValidateAsync(InnerUser user, InnerMessage message);
}