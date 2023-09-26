using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class EditShowedMessageEffect : ChatChangingEffectBase
{
    public EditShowedMessageEffect(Target target, Source source, byte order) : base(EffectType.EditShowedMessage, order)
    {
        Target = target;
        Source = source;
    }

    private EditShowedMessageEffect() { }

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