using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class ActiveKeyboardTriggerConfiguration : IEntityTypeConfiguration<ActiveKeyboardTrigger>
{
    public void Configure(EntityTypeBuilder<ActiveKeyboardTrigger> builder)
    {
        builder
            .HasOne<ChatScope>()
            .WithMany(cs => cs.PlainTriggers)
            .HasForeignKey(cs => cs.ChatScopeId)
            .HasConstraintName("AsPlain");
        builder
            .HasOne<ChatScope>()
            .WithMany(cs => cs.EncodedTriggers)
            .HasForeignKey(cs => cs.ChatScopeId)
            .HasConstraintName("AsEncoded");
    }
}