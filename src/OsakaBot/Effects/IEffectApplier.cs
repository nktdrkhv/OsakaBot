namespace Osaka.Bot.Effects;

public interface IEffectApplier
{
    Task Apply(EffectBase effect);
}

public interface IEffectApplier<T> : IEffectApplier
    where T : EffectBase
{ }