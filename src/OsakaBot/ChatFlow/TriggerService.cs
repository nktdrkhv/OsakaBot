using Microsoft.EntityFrameworkCore;
using Sqids;

namespace Osaka.Bot.ChatFlow;

public class TriggerService : ITriggerService
{
    private readonly IEffectDispatcher _effectDispatcher;
    private readonly SqidsEncoder _sqids;
    private readonly IRepository _repository;

    public TriggerService(IEffectDispatcher effectDispatcher, SqidsEncoder sqids, IRepository repository)
    {
        _effectDispatcher = effectDispatcher;
        _sqids = sqids;
        _repository = repository;
    }

    public async ValueTask ExecuteAsync(InnerUser user, Trigger trigger, string[]? args = null)
    {
        foreach (var effect in trigger.Effects)
            await ExecuteAsync(user, effect, args);
    }

    public async ValueTask ExecuteAsync(InnerUser user, EffectBase effect, string[]? args = null)
    {
        effect.User = user;
        if (args != null)
            effect.SetArguments(args);
        await _effectDispatcher.ResolveAsync(effect);
    }

    public async ValueTask<Trigger?> FromValidCustomInput(InnerUser user)
    {
        var scope = await _repository.GetAsync<ChatScope.ChatScope>(cs => cs.InnerUserId == user.InnerUserId,
            cs => cs
                .Include(cs => cs.OnValidInput),
            asNoTracking: true);
        return scope.OnValidInput;
    }

    public async ValueTask<Trigger?> FromInvalidCustomInput(InnerUser user)
    {
        var scope = await _repository.GetAsync<ChatScope.ChatScope>(cs => cs.InnerUserId == user.InnerUserId,
            cs => cs
                .Include(cs => cs.OnValidInput),
            asNoTracking: true);
        return scope.OnInvalidInput;
    }

    public async ValueTask<Trigger?> FromPlainPreparedAsync(InnerUser user, string prepared)
    {
        var scope = await _repository.GetAsync<ChatScope.ChatScope>(cs => cs.InnerUserId == user.InnerUserId,
            cs => cs
                .Include(cs => cs.PlainTriggers),
            asNoTracking: true);
        var triggerId = scope.PlainTriggers?.SingleOrDefault(pt => pt.Label == prepared)?.TriggerId;
        return triggerId is not null
            ? await _repository.GetByIdAsync<Trigger>(triggerId, t => t.Include(t => t.Effects), asNoTracking: true)
            : null;
    }

    public async ValueTask<Trigger?> FromEncodedPreparedAsync(InnerUser user, string encodedId)
    {
        var scope = await _repository.GetAsync<ChatScope.ChatScope>(cs => cs.InnerUserId == user.InnerUserId,
            cs => cs
                .Include(cs => cs.EncodedTriggers),
            asNoTracking: true);
        var triggerId = scope.EncodedTriggers?.SingleOrDefault(pt => pt.Label == encodedId)?.TriggerId;
        return triggerId is not null
            ? await _repository.GetByIdAsync<Trigger>(triggerId, t => t.Include(t => t.Effects), asNoTracking: true)
            : null;
    }

    public async ValueTask<Trigger?> FromEncodedStoredAsync(InnerUser user, string encodedId)
    {
        var ids = _sqids.Decode(encodedId);
        return ids.Length == 2 && ids[0] == user.InnerUserId ?
            await _repository.GetByIdAsync<Trigger>(ids[1], t => t.Include(t => t.Effects), asNoTracking: true) :
            null;
    }

    public string IntoEncodedId(InnerUser user, Trigger trigger) => _sqids.Encode(user.InnerUserId, trigger.TriggerId);
}