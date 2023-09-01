namespace Osaka.Bot.ChatFlow.ChatScope;

public class ChatScopeService : IChatScopeService
{
    private readonly IChatScopeStorage _chatScopeStorage;
    private readonly ITriggerService _triggerService;

    public ChatScopeService(IChatScopeStorage chatScopeStorage, ITriggerService triggerService)
    {
        _chatScopeStorage = chatScopeStorage;
        _triggerService = triggerService;
    }

    public async ValueTask CleanScopeAsync(InnerUser user)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        if (scope.OnClearScope is Trigger toExecute)
            await _triggerService.ExecuteAsync(user, toExecute);
        scope.ShowedMessages.Clear();
        scope.TriggerByPreparedPlain?.Clear();
        scope.TriggerByPreparedEncoded?.Clear();
        scope.Validators?.Clear();
        scope.ActiveInput = null;
        scope.OnValidInput = null;
        scope.OnInvalidInput = null;
        scope.HasToRedirectInvalidInput = false;
        await _chatScopeStorage.CommitChatScope(scope);
    }

    public async ValueTask<bool> HasCorrectionLoop(InnerUser user)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.HasToRedirectInvalidInput;
    }

    public ValueTask<Post?> GetActiveInputReasonAsync(InnerUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetInputToActiveAsync(InnerUser user, InnerMessage message)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetInputToReasonAsync(InnerUser user, Trigger trigger, InnerMessage message)
    {
        throw new NotImplementedException();
    }
}