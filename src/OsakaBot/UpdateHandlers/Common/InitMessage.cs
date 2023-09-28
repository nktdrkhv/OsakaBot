using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Helpers;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.Messages;

[Order(3), ChatType(ChatTypeFlags.Private)]
public sealed class InitMassage : MessageHandler
{
    private readonly ITextCommandService _textCommandService;
    private readonly IRepository _repository;
    private readonly UserStateKeeperAccessor _accessor;

    public InitMassage(ITextCommandService textCommandService, IRepository repository, UserStateKeeperAccessor accessor)
    {
        _textCommandService = textCommandService;
        _repository = repository;
        _accessor = accessor;
    }

    protected async override Task HandleAsync(IContainer<Message> cntr)
    {
        if (await _repository.GetAsync<InnerUser>(
            iu => iu.TelegramUserId == cntr.Sender()!.Id && !iu.SelfBlocked,
            iu => iu.Include(iu => iu.Role)) is InnerUser user)
        {
            TextCommand[] customCommands = Array.Empty<TextCommand>();
            if (user.IsCrew &&
                await _repository.GetAsync<CrewMember>(cm => cm.MemberId == user.InnerUserId, true) is CrewMember crew &&
                crew.CurrentMode != CrewMemberType.None)
            {
                await cntr.BotClient.SetMyCommandsAsync(Array.Empty<BotCommand>(), BotCommandScope.Chat(new(user.TelegramUserId)));

                if (crew.CurrentMode == CrewMemberType.Support)
                    _accessor.SetOrRenew(user.TelegramUserId, UserStateKeeperAccessor.Support, state: 0);
                else if (crew.CurrentMode == CrewMemberType.Admin)
                    _accessor.SetOrRenew(user.TelegramUserId, UserStateKeeperAccessor.Admin, state: 0);

                customCommands = crew.Role switch
                {
                    CrewMemberType.Support => new TextCommand[] { new TextCommand() { Name = "/support", Description = "В режим поддержки", Order = 20, Trigger = new(true, new CleanScopeEffect(true)) } },
                    CrewMemberType.Admin => new TextCommand[] { new TextCommand() { Name = "/admin", Description = "В режим администратора", Order = 30, Trigger = new(true, new CleanScopeEffect(true)) } },
                    CrewMemberType.SupporAdmin => new TextCommand[] { new TextCommand() { Name = "/support", Description = "В режим поддержки", Order = 20, Trigger = new(true, new CleanScopeEffect(true)) }, new TextCommand() { Name = "/admin", Description = "В режим администратора", Order = 30, Trigger = new(true, new CleanScopeEffect(true)) } },
                    _ => Array.Empty<TextCommand>()
                };
            }
            else
            {
                await _textCommandService.DisplayCommands(user, DisplayCommandsMode.Combine, customCommands);
                _accessor.SetOrRenew(user.TelegramUserId, UserStateKeeperAccessor.Regular, state: 0);
            }
            await cntr.Updater.WriteAsync(cntr.Container);
        }
        else
        {
            var key = $"startreq_{cntr.SenderId()!}";
            if (cntr.Updater.ContainsKey(key))
            {
                await cntr.Delete();
            }
            else
            {
                var msg = await cntr.ResponseAsync("Неизвестная команда, пожалуйста, <b>отправьте /start</b>", parseMode: ParseMode.Html);
                cntr.Updater[key] = new Tuple<DateTime, int, int>(DateTime.UtcNow, cntr.Update.MessageId, msg.Update.MessageId);
            }
        }
        StopPropagation();
    }
}