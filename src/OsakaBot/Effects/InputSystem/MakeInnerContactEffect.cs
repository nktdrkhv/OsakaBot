using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public sealed class MakeInnerContactEffect : EffectBase
{
    public MakeInnerContactEffect(byte order = 0) : base(EffectType.MakeInnerContact, order) { }

    private MakeInnerContactEffect() { }

    public override void SetArguments(object[] args) { }
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