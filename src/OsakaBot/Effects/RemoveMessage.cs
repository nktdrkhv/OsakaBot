using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class RemoveMessageEffect : EffectBase
{
    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
}

public class RemoveMessageEffectApplier : IEffectApplier<RemoveMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(RemoveMessageEffect effect) { }

    public Task Apply(EffectBase effect)
    {
        throw new NotImplementedException();
    }
}