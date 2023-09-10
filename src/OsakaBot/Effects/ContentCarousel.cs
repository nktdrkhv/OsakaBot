using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects;

public class ContentCarouselEffect : EffectBase
{
    // group
    [NotMapped] public int CurrentPosition { get; set; }
    [NotMapped] public bool IsMovingForward { get; set; }
    public override void SetArguments(string[] args)
    {
        if (args[0] != ButtonInlineCarousel.Identifier)
            return;
        CurrentPosition = int.Parse(args[1]);
        IsMovingForward = args[2] == "r";
    }
}

public class ContentCarouselEffectApplier : IEffectApplier<ContentCarouselEffect>
{
    private readonly ITelegramBotClient _botClient;

    public ContentCarouselEffectApplier(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task Apply(EffectBase effect)
    {
        var concrete = (ContentCarouselEffect)effect;
        await Task.CompletedTask;
    }
}