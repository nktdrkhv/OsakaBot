using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class RemoveShowedMessageEffect : EffectBase
{
    public RemoveShowedMessageEffect()
    {
        Type = EffectType.RemoveShowedMessage;
    }

    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
}

public class RemoveShowedMessageEffectApplier : IEffectApplier<RemoveShowedMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveShowedMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(RemoveShowedMessageEffect effect) { }

    public Task Apply(EffectBase effect)
    {
        throw new NotImplementedException();
    }
}