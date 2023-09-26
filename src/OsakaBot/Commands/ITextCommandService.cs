namespace Osaka.Bot.Commands;

public interface ITextCommandService
{
    ValueTask ExecuteCommand(InnerUser user, string command);
    ValueTask ExecuteCommand(InnerUser user, TextCommand command);
    ValueTask DisplayCommands(InnerUser user, DisplayCommandsMode mode, params TextCommand[] customCommands);
}