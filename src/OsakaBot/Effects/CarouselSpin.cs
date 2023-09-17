using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class CarouselSpinEffect : EffectBase
{
    // group
    [NotMapped] public int CurrentPosition { get; set; }
    [NotMapped] public bool IsMovingForward { get; set; }

    public CarouselSpinEffect()
    {
        Type = EffectType.CarouselSpin;
    }

    public override void SetArguments(string[] args)
    {
        if (args[0] != ButtonInlineCarousel.Identifier)
            return;
        CurrentPosition = int.Parse(args[1]);
        IsMovingForward = args[2] == "r";
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