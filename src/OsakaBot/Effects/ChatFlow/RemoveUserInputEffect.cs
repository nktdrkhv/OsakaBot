using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class RemoveUserInputEffect : ChatChangingEffectBase
{
    public RemoveUserInputOptions Options { get; private set; } = RemoveUserInputOptions.All;

    public RemoveUserInputEffect() => Type = EffectType.RemoveUserInput;

    public RemoveUserInputEffect(RemoveUserInputOptions options) : this() => Options = options;

    public override void SetArguments(string[] args) { }
}

public class RemoveUserInputEffectApplier : IEffectApplier<RemoveUserInputEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveUserInputEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveUserInputEffect)effect;
        await Task.CompletedTask;
    }
}