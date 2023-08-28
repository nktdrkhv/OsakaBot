using System.ComponentModel;
using System.Reflection;

namespace Osaka.Bot.Effects;

public interface IEffectDispatcher
{
    Task ResolveAsync<T>(T effect) where T : EffectBase;
}

public sealed class EffectDispatcher : IEffectDispatcher
{
    private readonly IServiceProvider _provider;
    private static readonly Type Generic = typeof(IEffectApplier<>);

    public EffectDispatcher(IServiceProvider provider) => _provider = provider;

    public async Task ResolveAsync<TEffect>(TEffect effect) where TEffect : EffectBase
    {
        var argType = effect.GetType();
        var constructed = Generic.MakeGenericType(argType);
        var applier = (IEffectApplier)_provider.GetRequiredService(constructed);
        await applier.Apply(effect);
    }
}