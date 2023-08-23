namespace Osaka.Bot.Effects;

public interface IEffectDispatcher
{
    Task ResolveAsync<T>(T effect) where T : EffectBase;
}