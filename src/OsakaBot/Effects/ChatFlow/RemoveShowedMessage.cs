using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class RemoveShowedMessageEffect : ChatChangeEffectBase
{
    public bool WithUserInput { get; set; } = true;

    public RemoveShowedMessageEffect() => Type = EffectType.RemoveShowedMessage;

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

    public ValueTask Apply(EffectBase effect)
    {
        throw new NotImplementedException();
    }
}