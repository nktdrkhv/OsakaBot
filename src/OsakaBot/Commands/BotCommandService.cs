namespace Osaka.Bot.Commands;

public class BotCommandService : IBotCommandService
{
    public ValueTask ExecuteCommand(InnerUser user, string command)
    {
        throw new NotImplementedException();
    }

    public ValueTask ExecuteCommand(InnerUser user, BotCommand command)
    {
        throw new NotImplementedException();
    }
}