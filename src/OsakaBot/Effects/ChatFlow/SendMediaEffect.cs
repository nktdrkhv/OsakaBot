using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class SendMediaEffect : ChatChangingEffectBase
{
    public SendMediaEffect(Media media, string label, byte order = 0) : base(EffectType.SendMedia, order)
        => Source = new(media, label);

    private SendMediaEffect() { }

    public override void SetArguments(object[] args) { }
}

public class SendMediaEffectApplier : IEffectApplier<SendMediaEffect>
{
    private readonly ITelegramBotClient _botClient;

    public SendMediaEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (SendMediaEffect)effect;
        await Task.CompletedTask;
    }
}