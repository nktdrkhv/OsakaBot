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
                .HasValue<CarouselSpinEffect>(EffectType.CarouselSpin)
                .HasValue<CleanScopeEffect>(EffectType.CleanScope)
                .HasValue<EditShowedMessageEffect>(EffectType.EditShowedMessage)
                .HasValue<RemoveInlineKeyboardEffect>(EffectType.RemoveInlineKeyboard)
                .HasValue<RemoveShowedMessageEffect>(EffectType.RemoveShowedMessage)
                .HasValue<RemoveUserInputEffect>(EffectType.RemoveUserInput)
                .HasValue<SendPostEffect>(EffectType.SendPost);
        builder
            .HasDiscriminator(et => et.Type)
                .HasValue<StartDialogueEffect>(EffectType.StartDialogue)
                .HasValue<FinishDialogueEffect>(EffectType.FinishDialogue)
                .HasValue<SendReportEffect>(EffectType.SendReport);
    }
}

public class ChatChangeEffectBaseConfiguration : IEntityTypeConfiguration<ChatChangingEffectBase>
{
    public void Configure(EntityTypeBuilder<ChatChangingEffectBase> builder)
    {
        builder
            .OwnsOne(cceb => cceb.Target);
        builder
            .OwnsOne(cceb => cceb.Source);
    }
}