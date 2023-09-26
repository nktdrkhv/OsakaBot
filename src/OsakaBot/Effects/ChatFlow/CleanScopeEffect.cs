using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class CleanScopeEffect : EffectBase
{
    public ICollection<Target>? Except { get; private set; }

    [Column("WithUserInput")] public bool WithUserInput { get; private set; } = true;

    public CleanScopeEffect(bool withUserInput, byte order = 0, params Target[] except) : base(EffectType.CleanScope, order)
    {
        WithUserInput = withUserInput;
        Except = except;
    }

    private CleanScopeEffect() { }
    public override void SetArguments(string[] args) { }
}

public class CleanScopeEffectApplier : IEffectApplier<CleanScopeEffect>
{
    private readonly ITelegramBotClient _botClient;

    public CleanScopeEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (CleanScopeEffect)effect;
        await Task.CompletedTask;
    }
}