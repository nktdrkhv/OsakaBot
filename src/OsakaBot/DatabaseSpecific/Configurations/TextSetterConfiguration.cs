using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class TextSetterConfiguration : IEntityTypeConfiguration<TextSetterBase>
{
    public void Configure(EntityTypeBuilder<TextSetterBase> builder)
    {
        builder
            .Property(t => t.Type)
                .HasConversion(new EnumToStringConverter<TextSetterType>());
        builder
            .HasDiscriminator(ts => ts.Type)
                .HasValue<EnteredDataTextSetter>(TextSetterType.EnteredData)
                .HasValue<ContactListTextSetter>(TextSetterType.ContactList)
                .HasValue<WeatherTextSetter>(TextSetterType.Weather)
                .HasValue<UserRoleTextSetter>(TextSetterType.UserRole)
                .HasValue<TicketsTextSetter>(TextSetterType.Tickets);
    }
}
