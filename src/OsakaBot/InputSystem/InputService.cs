namespace Osaka.Bot.InputSystem;

public class InputService : IInputService
{
    private readonly IDialogueService _dialogeService;
    private readonly IAutoInputService _autoInput;
    private readonly IRepository _repository;

    public InputService(IDialogueService dialogeService, IAutoInputService autoInput, IRepository repository)
    {
        _dialogeService = dialogeService;
        _autoInput = autoInput;
        _repository = repository;
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

    public ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger, string text)
    {
        throw new NotImplementedException();
    }
}