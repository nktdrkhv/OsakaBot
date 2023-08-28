namespace Osaka.Bot.Validation;

public interface IValidationService
{
    ValueTask<bool> ValidateAsync(InnerUser user, InnerMessage message);
    ValueTask<bool> ValidateAsync<T>(T data) where T : ValidationBase;
}