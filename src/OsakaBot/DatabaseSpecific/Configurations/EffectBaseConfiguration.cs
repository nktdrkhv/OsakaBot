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
                .HasValue<EditShowedMessageEffect>(EffectType.EditShowedMessage)
                .HasValue<RemoveInlineKeyboardEffect>(EffectType.RemoveInlineKeyboard)
                .HasValue<RemoveShowedMessageEffect>(EffectType.RemoveShowedMessage)
                .HasValue<RemoveUserInputEffect>(EffectType.RemoveUserInput)
                .HasValue<SendPostEffect>(EffectType.SendPost)
                .HasValue<CleanScopeEffect>(EffectType.CleanScope)
                .HasValue<StartDialogueEffect>(EffectType.StartDialogue)
                .HasValue<FinishDialogueEffect>(EffectType.FinishDialogue)
                .HasValue<SendReportEffect>(EffectType.SendReport)
                .HasValue<MakeInnerContactEffect>(EffectType.MakeInnerContact)
                .HasValue<SetPhraseEffect>(EffectType.SetPhrase);
    }
}

// public class ChatChangeEffectBaseConfiguration : IEntityTypeConfiguration<ChatChangingEffectBase>
// {
//     public void Configure(EntityTypeBuilder<ChatChangingEffectBase> builder)
//     {
//         builder
//             .OwnsOne(cceb => cceb.Target);
//         builder
//             .OwnsOne(cceb => cceb.Source);
//     }
// }

public class CleanScopeEffectConfiguration : IEntityTypeConfiguration<CleanScopeEffect>
{
    public void Configure(EntityTypeBuilder<CleanScopeEffect> builder)
    {
        builder
            .HasMany(cse => cse.Except)
            .WithMany();
    }
}