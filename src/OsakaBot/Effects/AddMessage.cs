using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class AddMessageEffect : EffectBase
{

}

public class AddMessageEffectApplier : IEffectApplier<AddMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public AddMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(AddMessageEffect effect) { }
}