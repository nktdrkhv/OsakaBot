using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveUserInputEffect : ChatChangingEffectBase
{
    public RemoveUserInputOptions Options { get; private set; } = RemoveUserInputOptions.All;

    public RemoveUserInputEffect(RemoveUserInputOptions options, byte order = 0) : base(EffectType.RemoveUserInput, order)
        => Options = options;

    private RemoveUserInputEffect() { }

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