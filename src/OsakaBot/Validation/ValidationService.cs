using System.Collections.Immutable;

namespace Osaka.Bot.Validation;

public sealed class ValidationService : IValidationService
{
    private readonly IChatScopeStorage _chatScopeStorage;

    public ValidationService(IChatScopeStorage chatScopeStorage) => _chatScopeStorage = chatScopeStorage;

    public async ValueTask<bool> ValidateAsync(InnerUser user, InnerMessage message)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.Validators is null || scope.Validators.GroupBy(v => v.PriorityGroup).Select(group =>
        {
            var result = true;
            foreach (var validator in group)
                result &= validator.Validate(message);
            return result;
        }).Any(conjunction => conjunction);
    }
}