using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Osaka.Bot.DatabaseSpecific;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    { }
}

// var converter = new EnumToStringConverter<UserRole>();

// modelBuilder
//   .Entity<User>()
//   .Property(e => e.UserRole)
//   .HasConversion(converter);