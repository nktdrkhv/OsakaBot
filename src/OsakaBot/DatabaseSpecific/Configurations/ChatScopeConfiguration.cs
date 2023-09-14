using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class ChatScopeConfiguration : IEntityTypeConfiguration<ChatScope>
{
    public void Configure(EntityTypeBuilder<ChatScope> builder)
    {
        builder
            .HasMany(cm => cm.ShowedMessages)
                .WithOne(sm => sm.ChatScope);
    }
}