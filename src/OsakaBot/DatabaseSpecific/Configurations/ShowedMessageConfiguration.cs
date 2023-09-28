using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class ShowedMessageConfiguration : IEntityTypeConfiguration<ShowedMessage>
{
    public void Configure(EntityTypeBuilder<ShowedMessage> builder)
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
            .Property(sm => sm.CauseMessagesIds)
                .HasConversion(converter);
    }
}