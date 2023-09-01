using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.DatabaseSpecific;

public class BotDbContext : DbContext
{
    public DbSet<InnerUser> InnerUsers { get; set; } = null!;
    public DbSet<ChatScope> ChatScopes { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<ButtonBase> Buttons { get; set; } = null!;
    public DbSet<Trigger> Triggers { get; set; } = null!;

    public BotDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=oez.db");
    }
}