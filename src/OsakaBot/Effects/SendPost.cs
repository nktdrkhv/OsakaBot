using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class SendPostEffect : EffectBase
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    public SendPostEffect()
    {
        Type = EffectType.SendPost;
    }

    public override void SetArguments(string[] args) { }
}

public class SendPostEffectApplier : IEffectApplier<SendPostEffect>
{
    private readonly ITelegramBotClient _botClient;

    public SendPostEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(EffectBase effect)
    {
        var concrete = (SendPostEffect)effect;
        await Task.CompletedTask;
    }
}