using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public sealed class StartDialogueEffect : DialogueEffectBase
{
    public StartDialogueEffect(Dialogue? dialogue, byte order = 0) : base(dialogue, EffectType.StartDialogue, order) { }

    private StartDialogueEffect() { }

    public override void SetArguments(object[] args) { }
}

public class StartDialogueEffectApplier : IEffectApplier<StartDialogueEffect>
{
    private readonly ITelegramBotClient _botClient;

    public StartDialogueEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (StartDialogueEffect)effect;
        await Task.CompletedTask;
    }
}