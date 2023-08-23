namespace Osaka.Bot.Effects;

public interface IEffectApplier<T> where T : EffectBase
{
    Task Apply(T effect);
}