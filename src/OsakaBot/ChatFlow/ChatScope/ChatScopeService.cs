using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Requests;

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
        scope.UserInput = null;
        scope.ActiveInput = null;
        scope.HasToRedirectInvalidInput = false;
    }

    public async ValueTask<bool> HasCorrectionLoop(InnerUser user)
    {
        return await (from cs in _repository.GetQueryable<ChatScope>().AsNoTracking()
                      where cs.InnerUserId == user.InnerUserId
                      select cs.HasToRedirectInvalidInput).SingleAsync();
    }

    public async ValueTask SetInputToActiveAsync(InnerUser user, InnerMessage message) => await _repository.SetUserInput(user, message);

    public async ValueTask SetInputToCustomAsync(InnerUser user, InnerMessage message, Target target) => await _repository.SetUserInput(user, message, target);

    public async ValueTask SetInputToReasonAsync(InnerUser user, InnerMessage message, Trigger trigger) => await _repository.SetUserInput(user, message, trigger);
}