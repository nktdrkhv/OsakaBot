using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class ButtonBaseConfiguration : IEntityTypeConfiguration<ButtonBase>
{
    public void Configure(EntityTypeBuilder<ButtonBase> builder)
    {
        builder
            .HasDiscriminator(bb => bb.Type)
                .HasValue<ButtonInline>(ButtonType.Inline)
                .HasValue<ButtonInlineCarousel>(ButtonType.InlineCarousel)
                .HasValue<ButtonInlineEncoded>(ButtonType.InlineEncoded)
                .HasValue<ButtonReply>(ButtonType.Reply);
    }
}