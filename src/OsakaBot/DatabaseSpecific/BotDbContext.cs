using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;

namespace Osaka.Bot.DatabaseSpecific;

public class BotDbContext : DbContext
{
    public DbSet<InnerUser> InnerUsers { get; set; } = null!;
    public DbSet<ChatScope> ChatScopes { get; set; } = null!;
    public DbSet<ShowedMessage> ShowedMessages { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<GroupedContent> GroupedContents { get; set; } = null!;
    public DbSet<InnerMessage> InnerMessages { get; set; } = null!;
    public DbSet<ButtonBase> Buttons { get; set; } = null!;
    public DbSet<Trigger> Triggers { get; set; } = null!;
    public DbSet<Variable> Variables { get; set; } = null!;
    public DbSet<ActualDialogue> ActualDialogues { get; set; } = null!;
    public DbSet<ActiveKeyboardTrigger> ActiveKeyboardTriggers { get; set; } = null!;
    public DbSet<ActiveGroup> ActiveGroups { get; set; } = null!;
    public DbSet<IncludedPost> IncludedPosts { get; set; } = null!;
    public DbSet<Dialogue> Dialogues { get; set; } = null!;
    public DbSet<EnteredData> EnteredData { get; set; } = null!;
    public DbSet<TextCommand> BotCommands { get; set; } = null!;
    public DbSet<Target> Targets { get; set; } = null!;
    public DbSet<Source> Sources { get; set; } = null!;
    public DbSet<EffectBase> Effects { get; set; } = null!;
    public DbSet<Report> Reports { get; set; } = null!;

    public BotDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=oeztomsk.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
    }
}