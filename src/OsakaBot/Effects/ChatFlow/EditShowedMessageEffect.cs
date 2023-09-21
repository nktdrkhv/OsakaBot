using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class EditShowedMessageEffect : ChatChangingEffectBase
{
    public EditShowedMessageEffect() => Type = EffectType.EditShowedMessage;

    public override void SetArguments(string[] args) { }
}

public class EditShowedMessageEffectApplier : IEffectApplier<EditShowedMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public EditShowedMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (EditShowedMessageEffect)effect;
        await Task.CompletedTask;
    }
}