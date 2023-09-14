using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class InnerMessageConfiguration : IEntityTypeConfiguration<InnerMessage>
{
    public void Configure(EntityTypeBuilder<InnerMessage> builder)
    {
        var converter = new ValueConverter<int[]?, string?>(
                v => v == null
                    ? null
                    : string.Join(";", v),
                v => string.IsNullOrWhiteSpace(v)
                    ? null
                    : v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToArray()
                );
        builder
            .Property(im => im.CauseMessagesIds)
                .HasConversion(converter);
        builder
            .HasMany(im => im.SentByUser)
            .WithMany(sm => sm.RecievedFromUser);
        builder
            .HasMany(im => im.ShowingBy)
            .WithOne(sm => sm.InnerMessage);
    }
}