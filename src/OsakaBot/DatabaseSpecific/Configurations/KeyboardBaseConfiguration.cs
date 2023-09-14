using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class KeyboardBaseConfiguration : IEntityTypeConfiguration<KeyboardBase>
{
    public void Configure(EntityTypeBuilder<KeyboardBase> builder)
    {
        builder
            .HasDiscriminator(kb => kb.Type)
                .HasValue<KeyboardInline>(KeyboardType.Inline)
                .HasValue<KeyboardInlineDayPicker>(KeyboardType.InlineDayPicker)
                .HasValue<KeyboardReply>(KeyboardType.Reply)
                .HasValue<KeyboardRemove>(KeyboardType.Remove);
    }
}