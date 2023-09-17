using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class EffectBaseConfiguration : IEntityTypeConfiguration<EffectBase>
{
    public void Configure(EntityTypeBuilder<EffectBase> builder)
    {
        builder
            .HasDiscriminator(et => et.Type)
                .HasValue<CarouselSpinEffect>(EffectType.ContentCarouselSpin)
                .HasValue<SendPostEffect>(EffectType.SendPost)
                .HasValue<RemoveInlineKeyboardEffect>(EffectType.RemoveInlineKeyboard)
                .HasValue<RemoveShowedMessageEffect>(EffectType.RemoveShowedMessage);
    }
}

public class ChatChangeEffectBaseConfiguration : IEntityTypeConfiguration<ChatChangeEffectBase>
{
    public void Configure(EntityTypeBuilder<ChatChangeEffectBase> builder)
    {
        builder
            .OwnsOne(cceb => cceb.Target);
        builder
            .OwnsOne(cceb => cceb.Source);
    }
}