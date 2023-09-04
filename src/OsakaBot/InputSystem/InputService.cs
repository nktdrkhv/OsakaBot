namespace Osaka.Bot.InputSystem;

public class InputService : IInputService
{
    private IChatScopeStorage _chatScopeStorage;
    private IDialogueService _dialogeService;
    private IAutoInput _autoInput;

    public InputService(IChatScopeStorage chatScopeStorage, IDialogueService dialogeService, IAutoInput autoInput)
    {
        _chatScopeStorage = chatScopeStorage;
        _dialogeService = dialogeService;
        _autoInput = autoInput;
    }

    public async ValueTask<bool> IsThereAnyActiveDialogue(InnerUser user)
    {
        // todo: weard but anyway
        // var scope = await _chatScopeStorage.RetrieveChatScope(user);
        // return scope.IsAnyActiveDialogue;
        throw new NotImplementedException();
    }

    public ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger)
    {
        //var scope = await _chatScopeStorage.RetrieveChatScope(user);
        throw new NotImplementedException();
    }

    public ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger, InnerMessage message)
    {
        throw new NotImplementedException();
    }

    public ValueTask AssignFromConcreteMessage(InnerUser user, int messageId, string data)
    {
        throw new NotImplementedException();
    }
}