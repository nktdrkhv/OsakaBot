using Sqids;

namespace Osaka.Bot.ChatFlow;

public class TriggerService : ITriggerService
{
    private readonly IChatScopeStorage _chatScopeStorage;
    private readonly ITriggerStorage _triggerStorage;
    private readonly IEffectDispatcher _effectDispatcher;
    private readonly SqidsEncoder _sqids;

    public TriggerService(IChatScopeStorage chatScopeStorage, ITriggerStorage triggerStorage, IEffectDispatcher effectDispatcher, SqidsEncoder sqids)
    {
        _chatScopeStorage = chatScopeStorage;
        _triggerStorage = triggerStorage;
        _effectDispatcher = effectDispatcher;
        _sqids = sqids;
    }

    public async ValueTask ExecuteAsync(InnerUser user, Trigger trigger)
    {
        foreach (var effect in trigger.Effects)
        {
            effect.User = user;
            await _effectDispatcher.ResolveAsync(effect);
        }
    }

    public async ValueTask ExecuteAsync(InnerUser user, EffectBase effect)
    {
        // todo: attach scope
        effect.User = user;
        await _effectDispatcher.ResolveAsync(effect);
        // todo: save scope
    }

    public async ValueTask<Trigger?> FromValidCustomInput(InnerUser user)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.OnValidInput;
    }

    public async ValueTask<Trigger?> FromInvalidCustomInput(InnerUser user)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.OnInvalidInput;
    }

    public async ValueTask<Trigger?> FromPlainPreparedAsync(InnerUser user, string prepared)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.TriggerByPreparedPlain?.SingleOrDefault(at => at.CustomLabel == prepared)?.TriggerItself;
    }

    public async ValueTask<Trigger?> FromEncodedPreparedAsync(InnerUser user, string encodedId)
    {
        var scope = await _chatScopeStorage.RetrieveChatScope(user);
        return scope.TriggerByPreparedEncoded?.SingleOrDefault(at => at.CustomLabel == encodedId)?.TriggerItself;
    }

    public async ValueTask<Trigger?> FromEncodedStoredAsync(InnerUser user, string encodedId)
    {
        var ids = _sqids.Decode(encodedId);
        return ids[0] == user.InnerUserId ?
            await _triggerStorage.RetrieveTrigger(ids[1]) :
            null;
    }

    public string IntoEncodedId(InnerUser user, Trigger trigger) => _sqids.Encode(user.InnerUserId, trigger.TriggerId);
}