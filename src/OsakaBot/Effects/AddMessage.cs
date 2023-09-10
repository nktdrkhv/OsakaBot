using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class AddMessageEffect : EffectBase
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public override void SetArguments(string[] args) { }
}

public class AddMessageEffectApplier : IEffectApplier<AddMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public AddMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(EffectBase effect)
    {
        var concrete = (AddMessageEffect)effect;
        await Task.CompletedTask;
    }
}