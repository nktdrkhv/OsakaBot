namespace Osaka.Bot.ChatFlow;

public class TriggerService : ITriggerService
{
    private readonly IChatScopeService _chatScopeService;
    private readonly IEffectDispatcher _effectDispatcher;

    public TriggerService(IChatScopeService chatScopeService, IEffectDispatcher effectDispatcher)
    {
        _chatScopeService = chatScopeService;
        _effectDispatcher = effectDispatcher;
    }

    public async ValueTask ExecuteAsync(InnerUser user, Trigger trigger)
    {
        if (trigger.AllowOutOfScope || await _chatScopeService.IsTriggerInTheScopeAsync(user, trigger))
            foreach (var effect in trigger.Effects)
            {
                effect.User = user;
                await _effectDispatcher.ResolveAsync(effect);
            }
        else
        {
            var removeInlineKeyboard = new RemoveInlineKeyboardEffect() { TargetMessageId = await AttachedMessageId(trigger) };
            await _effectDispatcher.ResolveAsync(removeInlineKeyboard);
        }
    }

    public ValueTask<Trigger?> FromCorrectCustomInput(InnerUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Trigger?> FromEncodedAsync(InnerUser user, string encodedId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Trigger?> FromIncorrectCustomInput(InnerUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Trigger?> FromPreparedAsync(InnerUser user, string prepared)
    {
        throw new NotImplementedException();
    }

    private async ValueTask<int> AttachedMessageId(Trigger trigger)
    {
        return default;
    }
}