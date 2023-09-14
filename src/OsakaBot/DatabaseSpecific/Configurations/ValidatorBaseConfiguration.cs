using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class ValidatorBaseConfiguration : IEntityTypeConfiguration<ValidatorBase>
{
    public void Configure(EntityTypeBuilder<ValidatorBase> builder)
    {
        builder
            .Property(v => v.Type)
                .HasConversion(new EnumToStringConverter<ValidatorType>());
        builder
            .HasDiscriminator(ts => ts.Type)
                .HasValue<MessageTypeValidator>(ValidatorType.MessageType)
                .HasValue<NameValidator>(ValidatorType.Name)
                .HasValue<EmailValidator>(ValidatorType.Email)
                .HasValue<PhoneValidator>(ValidatorType.Phone);
    }
}
