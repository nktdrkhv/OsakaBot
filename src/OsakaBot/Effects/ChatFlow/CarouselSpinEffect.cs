using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class CarouselSpinEffect : ChatChangingEffectBase
{
    [NotMapped] public int CurrentPosition { get; private set; }
    [NotMapped] public bool IsMovingForward { get; private set; }

    public int GroupId { get; private set; }
    public Group Group { get; private set; } = null!;

    public CarouselSpinEffect(Target target, Group group, byte order = 0) : base(EffectType.CarouselSpin, order)
    {
        Target = target;
        Group = group;
    }

    private CarouselSpinEffect() { }

    public override void SetArguments(string[] args)
    {
        if (args[0] != ButtonInlineCarousel.Identifier)
            return;
        CurrentPosition = int.Parse(args[1]);
        IsMovingForward = args[2] == ButtonInlineCarousel.Rightward;
    }
}

public class CarouselSpinEffectApplier : IEffectApplier<CarouselSpinEffect>
{
    private readonly ITelegramBotClient _botClient;

    public CarouselSpinEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (CarouselSpinEffect)effect;
        await ValueTask.CompletedTask;
    }
}