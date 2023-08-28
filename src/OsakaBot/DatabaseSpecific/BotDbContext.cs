using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.DatabaseSpecific;

public class BotDbContext : DbContext
{
    public BotDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=oez.db");
    }
}