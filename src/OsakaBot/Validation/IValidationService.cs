namespace Osaka.Bot.Validation;

public interface IValidationService
{
    ValueTask<bool> ValidateAsync<T>(T data) where T : ValidationBase;
}