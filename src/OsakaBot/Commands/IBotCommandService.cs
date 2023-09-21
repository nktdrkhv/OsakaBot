namespace Osaka.Bot.Commands;

public interface IBotCommandService
{
    ValueTask ExecuteCommand(InnerUser user, string command);
    ValueTask ExecuteCommand(InnerUser user, BotCommand command);
}