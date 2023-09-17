using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class CleanScopeEffect : EffectBase
{
    public CleanScopeEffect() => Type = EffectType.CleanScope;

    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
}

public class CleanScopeEffectApplier : IEffectApplier<CleanScopeEffect>
{
    private readonly ITelegramBotClient _botClient;

    public CleanScopeEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (CleanScopeEffect)effect;
        await Task.CompletedTask;
    }
}