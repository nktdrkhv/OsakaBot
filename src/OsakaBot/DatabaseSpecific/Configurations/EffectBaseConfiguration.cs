using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class EffectBaseConfiguration : IEntityTypeConfiguration<EffectBase>
{
    public void Configure(EntityTypeBuilder<EffectBase> builder)
    {
        builder
            .HasDiscriminator(et => et.Type)
                .HasValue<MakeInnerContactEffect>(EffectType.MakeInnerContact)
                .HasValue<SetPhraseEffect>(EffectType.SetPhrase)
                .HasValue<CleanScopeEffect>(EffectType.CleanScope)
                .HasValue<RemoveShowedMessageEffect>(EffectType.RemoveShowedMessage)
                .HasValue<RemoveUserInputEffect>(EffectType.RemoveUserInput)
                .HasValue<RemoveInlineKeyboardEffect>(EffectType.RemoveInlineKeyboard)
                .HasValue<EditShowedMessageEffect>(EffectType.EditShowedMessage)
                .HasValue<CarouselSpinEffect>(EffectType.CarouselSpin)
                .HasValue<SendPostEffect>(EffectType.SendPost)
                .HasValue<SendReportEffect>(EffectType.SendReport)
                .HasValue<SendMediaEffect>(EffectType.SendMedia)
                .HasValue<SendReportAssistantsContactsEffect>(EffectType.SendReportAssistantsContacts)
                .HasValue<StartDialogueEffect>(EffectType.StartDialogue)
                .HasValue<FinishDialogueEffect>(EffectType.FinishDialogue);
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