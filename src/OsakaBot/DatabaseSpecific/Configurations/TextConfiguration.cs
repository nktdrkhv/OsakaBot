using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class TextConfiguration : IEntityTypeConfiguration<Text>
{
    public void Configure(EntityTypeBuilder<Text> builder)
    {
        var converter = new ValueConverter<ICollection<MessageEntity>?, string?>(
                v => v == null
                    ? null
                    : JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => string.IsNullOrWhiteSpace(v)
                    ? null
                    : JsonConvert.DeserializeObject<ICollection<MessageEntity>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                );
        builder
            .Property(t => t.OriginalEntities)
                .HasConversion(converter);
    }
}
