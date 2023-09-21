using Telegram.Bot;

namespace Osaka.Bot.Effects.InputSystem;

public class StartDialogueEffect : EffectBase
{
    public StartDialogueEffect() => Type = EffectType.StartDialogue;

    public override void SetArguments(string[] args)
    {
        throw new NotImplementedException();
    }
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