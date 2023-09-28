using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public sealed class FinishDialogueEffect : DialogueEffectBase
{
    public FinishDialogueEffect(Dialogue? dialogue, byte order = 0) : base(dialogue, EffectType.FinishDialogue, order) { }
    private FinishDialogueEffect() { }
    public override void SetArguments(object[] args) { }
}

public class FinishDialogueEffectApplier : IEffectApplier<FinishDialogueEffect>
{
    private readonly ITelegramBotClient _botClient;

    public FinishDialogueEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (FinishDialogueEffect)effect;
        await Task.CompletedTask;
    }
}