using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Osaka.Bot.DatabaseSpecific.Configurations;

public class InnerUserConfiguration : IEntityTypeConfiguration<InnerUser>
{
    public void Configure(EntityTypeBuilder<InnerUser> builder)
    {
        // builder
        //     .HasOne(iu => iu.ChatScope)
        //     .WithOne(cs => cs.InnerUser);
    }
}