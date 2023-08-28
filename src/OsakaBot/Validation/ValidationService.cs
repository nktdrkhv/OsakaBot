namespace Osaka.Bot.Validation;

public sealed class ValidationService : IValidationService
{
    public async ValueTask<bool> ValidateAsync(InnerUser user, InnerMessage message)
    {
        return false;
    }

    public ValueTask<bool> ValidateAsync<T>(T data) where T : ValidationBase
    {
        return data switch
        {
            Validation.MessageTypeValidation => MessageTypeValidation(data),
            _ => ValueTask.FromResult(false)
        };
    }

    public static ValueTask<bool> MessageTypeValidation<T>(T data) where T : ValidationBase
    {
        return ValueTask.FromResult(false);
    }
}