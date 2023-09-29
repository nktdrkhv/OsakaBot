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
    public override void SetArguments(object[] args) { }
}

public class CleanScopeEffectApplier : IEffectApplier<CleanScopeEffect>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IRepository _repository;

    public CleanScopeEffectApplier(ITelegramBotClient botClient, IRepository repository)
    {
        _botClient = botClient;
        _repository = repository;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (CleanScopeEffect)effect;
        var scope = _repository.GetUserScope(concrete.User);

        List<ShowedMessage> exepts = new();
        foreach (var target in concrete.Except!)
            exepts.Add(await _repository.GetShowedMessageByTarget(concrete.User, target));


        throw new NotImplementedException();
    }
}
