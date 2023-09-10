namespace Osaka.Bot.Validation;

public sealed class ValidationService : IValidationService
{
    private readonly IRepository _repository;

    public ValidationService(IRepository repository) => _repository = repository;

    public async ValueTask<bool> ValidateAsync(InnerUser user, InnerMessage message)
    {
        var validators = await _repository.GetValidators(user);
        return validators is null || validators.GroupBy(v => v.PriorityGroup).Select(group =>
        {
            var result = true;
            foreach (var validator in group)
                result &= validator.Validate(message);
            return result;
        }).Any(conjunction => conjunction);
    }
}