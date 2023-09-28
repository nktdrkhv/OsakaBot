using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class CarouselSpinEffect : ChatChangingEffectBase
{
    //[NotMapped] public int CurrentPosition { get; private set; }
    [NotMapped] public bool IsMovingForward { get; private set; }
    [NotMapped] public string CurrentTriggerCode { get; private set; } = null!;

    public int GroupId { get; private set; }
    public Group Group { get; private set; } = null!;

    public CarouselSpinEffect(Target target, Group group, byte order = 0) : base(EffectType.CarouselSpin, order)
    {
        Target = target;
        Group = group;
    }

    private CarouselSpinEffect() { }

    public override void SetArguments(object[] args) // sa2qa:cc:r
    {
        if (args[1] as string != ButtonInlineCarousel.Identifier)
            return;
        //CurrentPosition = int.Parse((string)args[1]);
        IsMovingForward = args[2] as string == ButtonInlineCarousel.Rightward;
        CurrentTriggerCode = (string)args[0];
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