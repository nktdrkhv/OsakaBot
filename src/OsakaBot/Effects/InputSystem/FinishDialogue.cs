using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public class FinishDialogueEffect : EffectBase
{
    public FinishDialogueEffect() => Type = EffectType.FinishDialogue;

    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
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