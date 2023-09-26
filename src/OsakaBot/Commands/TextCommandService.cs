using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.Commands;

public class TextCommandService : ITextCommandService
{
    private readonly IRepository _repository;

    public TextCommandService(IRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask DisplayCommands(InnerUser user, DisplayCommandsMode mode, params TextCommand[] customCommands)
    {
        var commands = await _repository.GetListAsync<TextCommand>(
                    bc => bc.RoleVisibility!.Contains(user.Role!) && bc.PhraseVisibility == null,
                    bc => bc.Include(bc => bc.RoleVisibility),
                    asNoTracking: true);
        throw new NotImplementedException();
    }

    public ValueTask ExecuteCommand(InnerUser user, string command)
    {
        throw new NotImplementedException();
    }

    public ValueTask ExecuteCommand(InnerUser user, TextCommand command)
    {
        throw new NotImplementedException();
    }
}