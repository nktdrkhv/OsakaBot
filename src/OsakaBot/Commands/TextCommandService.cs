using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Osaka.Bot.Commands;

public class TextCommandService : ITextCommandService
{
    private readonly ITelegramBotClient _client;
    private readonly IRepository _repository;
    private readonly ITriggerService _triggerService;

    public TextCommandService(ITelegramBotClient client, IRepository repository, ITriggerService triggerService)
    {
        _client = client;
        _repository = repository;
        _triggerService = triggerService;
    }

    public async ValueTask DisplayCommands(InnerUser user, DisplayCommandsMode mode, params TextCommand[] customCommands)
    {
        switch (mode)
        {
            case DisplayCommandsMode.OnlyStored:
                var stored = await _repository.GetRelevantTextCommands(user);
                await SetCommands(user, stored.OrderBy(tc => tc.Order));
                break;
            case DisplayCommandsMode.OnlyCustom:
                await SetCommands(user, customCommands.OrderBy(tc => tc.Order));
                break;
            case DisplayCommandsMode.Combine:
                var combined = (await _repository.GetRelevantTextCommands(user)).Concat(customCommands);
                await SetCommands(user, combined.OrderBy(tc => tc.Order));
                break;
        }
    }

    private async ValueTask SetCommands(InnerUser user, IEnumerable<TextCommand> commands)
    {
        var scope = BotCommandScope.Chat(user.TelegramUserId);
        var botCommands = commands.Select((tc, _) => new BotCommand()
        {
            Command = tc.Name,
            Description = tc.Description
        });
        await _client.SetMyCommandsAsync(botCommands, scope);
    }

    public async ValueTask ExecuteCommand(InnerUser user, string command)
    {
        var textCommand = await _repository.GetAsync<TextCommand>(tc => tc.Name == command, tc => tc.Include(tc => tc.Trigger));
        if (textCommand == null)
            return;
        await _triggerService.ExecuteAsync(user, textCommand.Trigger);
    }

    public async ValueTask ExecuteCommand(InnerUser user, TextCommand command)
    {
        var trigger = await _repository.GetByIdAsync<Trigger>(command.TriggerId);
        await _triggerService.ExecuteAsync(user, trigger);
    }
}