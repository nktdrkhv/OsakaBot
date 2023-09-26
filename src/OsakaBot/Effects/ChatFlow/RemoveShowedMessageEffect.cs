using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveShowedMessageEffect : ChatChangingEffectBase
{
    [Column("WithUserInput")]
    public bool WithUserInput { get; private set; } = true;

    public RemoveShowedMessageEffect(Target target, bool withUserInput = true, byte order = 0) : base(EffectType.RemoveShowedMessage, order)
    {
        Target = target;
        WithUserInput = withUserInput;
    }

    private RemoveShowedMessageEffect() { }

    public override void SetArguments(string[] args) { }
}

public class RemoveShowedMessageEffectApplier : IEffectApplier<RemoveShowedMessageEffect>
{
    private readonly ITelegramBotClient _botClient;

    public RemoveShowedMessageEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveShowedMessageEffect)effect;
        await Task.CompletedTask;
    }
}