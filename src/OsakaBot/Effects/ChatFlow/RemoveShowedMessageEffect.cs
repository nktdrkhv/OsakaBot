using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public class RemoveShowedMessageEffect : ChatChangingEffectBase
{
    [Column("WithUserInput")]
    public bool WithUserInput { get; set; } = true;

    public RemoveShowedMessageEffect() => Type = EffectType.RemoveShowedMessage;

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