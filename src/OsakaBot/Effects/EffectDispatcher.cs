namespace Osaka.Bot.Effects;

public sealed class EffectDispatcher : IEffectDispatcher
{
    private readonly IServiceProvider _provider;

    public EffectDispatcher(IServiceProvider provider) => _provider = provider;

    public async Task ResolveAsync<T>(T effect) where T : EffectBase
    {
        var applier = _provider.GetRequiredService<IEffectApplier<T>>();
        await applier.Apply(effect);
    }
}