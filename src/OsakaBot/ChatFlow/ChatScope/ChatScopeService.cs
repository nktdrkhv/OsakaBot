namespace Osaka.Bot.ChatFlow.ChatScope;

public class ChatScopeService : IChatScopeService
{
    private readonly IRepository _repository;
    private readonly ITriggerService _triggerService;

    public ChatScopeService(IRepository repository, ITriggerService triggerService)
    {
        _repository = repository;
        _triggerService = triggerService;
    }

    public async ValueTask CleanScopeAsync(InnerUser user)
    {
        var scope = await _repository.GetUserScope(user);
        if (scope.OnScopeClean is Trigger toExecute)
            await _triggerService.ExecuteAsync(user, toExecute);
        scope.ShowedMessages.Clear();
        scope.PlainTriggers?.Clear();
        scope.EncodedTriggers?.Clear();
        scope.Validators?.Clear();
        scope.ActiveInput = null;
        scope.OnValidInput = null;
        scope.OnInvalidInput = null;
        scope.HasToRedirectInvalidInput = false;
    }

    public async ValueTask<bool> HasCorrectionLoop(InnerUser user)
    {
        var scope = await _repository.GetAsync<ChatScope>(sc => sc.InnerUserId == user.InnerUserId, asNoTracking: true);
        return scope.HasToRedirectInvalidInput;
    }

    public async ValueTask SetInputToActiveAsync(InnerUser user, InnerMessage message) => await _repository.SetUserInput(user, message);

    public async ValueTask SetInputToReasonAsync(InnerUser user, Trigger trigger, InnerMessage message) => await _repository.SetUserInput(user, message, trigger);
}