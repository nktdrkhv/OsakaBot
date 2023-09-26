using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class SetPhraseEffect : EffectBase
{
    public string? Phrase { get; private set; }

    public SetPhraseEffect(string? phrase, byte order = 0) : base(EffectType.SetPhrase, order)
        => Phrase = phrase;

    private SetPhraseEffect() { }

    public override void SetArguments(string[] args) { }
}

public class SetPhraseEffectApplier : IEffectApplier<SetPhraseEffect>
{
    private readonly ITelegramBotClient _botClient;

    public SetPhraseEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (SetPhraseEffect)effect;
        await Task.CompletedTask;
    }
}