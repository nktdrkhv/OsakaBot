namespace Osaka.Bot.ChatFlow;

public class SqlTriggerStorage : ITriggerStorage
{
    private readonly BotDbContext _botDbContext;

    public SqlTriggerStorage(BotDbContext botDbContext) => _botDbContext = botDbContext;

    public async ValueTask<Trigger?> RetrieveTrigger(int triggerId) => await _botDbContext.Triggers.FindAsync(triggerId);
}