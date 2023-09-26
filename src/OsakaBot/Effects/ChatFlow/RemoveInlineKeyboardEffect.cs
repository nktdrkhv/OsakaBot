using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveInlineKeyboardEffect : ChatChangingEffectBase
{
    public RemoveInlineKeyboardEffect(Target target, byte order = 0) : base(EffectType.RemoveInlineKeyboard, order)
        => Target = target;

    private RemoveInlineKeyboardEffect() { }

    public override void SetArguments(string[] args) { }
}

public class RemoveInlineKeyboardEffectApplier : IEffectApplier<RemoveInlineKeyboardEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveInlineKeyboardEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveInlineKeyboardEffect)effect;
        await Task.CompletedTask;
    }
}