namespace Osaka.Bot.Effects;

public interface IEffectApplier
{
    ValueTask Apply(EffectBase effect);
}

public interface IEffectApplier<T> : IEffectApplier
    where T : EffectBase
{ }