using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public class MakeInnerContactEffect : EffectBase
{
    public MakeInnerContactEffect() => Type = EffectType.MakeInnerContact;

    public override void SetArguments(string[] args) { }
}

public class MakeInnerContactEffectApplier : IEffectApplier<MakeInnerContactEffect>
{
    private readonly ITelegramBotClient _botClient;

    public MakeInnerContactEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (MakeInnerContactEffect)effect;
        await Task.CompletedTask;
    }
}