using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class RemoveInlineKeyboardEffect : ChatChangingEffectBase
{
    public RemoveInlineKeyboardEffect() => Type = EffectType.RemoveInlineKeyboard;

    public override void SetArguments(string[] args) { }
}

public class RemoveInlineKeyboardEffectApplier : IEffectApplier<SendPostEffect>
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