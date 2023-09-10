using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class RemoveInlineKeyboardEffect : EffectBase
{
    public int TargetMessageId { get; set; }

    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
}

public class RemoveInlineKeyboardEffectApplier : IEffectApplier<AddMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveInlineKeyboardEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(EffectBase effect)
    {
        var concrete = (RemoveInlineKeyboardEffect)effect;
        await Task.CompletedTask;
    }
}