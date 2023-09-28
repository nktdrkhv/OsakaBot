using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.Common.MyChatMembers;

[Order(0)]
public sealed class MyChatMember : MyChatMemberHandler
{
    private readonly IRepository _repository;

    public MyChatMember(IRepository repository) => _repository = repository;

    protected async override Task HandleAsync(IContainer<ChatMemberUpdated> cntr)
    {
        var status = cntr.Update;
        if (await _repository.GetInnerUser(status.From) is InnerUser user)
        {
            if (status.NewChatMember.Status.HasFlag(ChatMemberStatus.Kicked))
                user.SelfBlocked = true;
            if (status.NewChatMember.Status.HasFlag(ChatMemberStatus.Member))
                user.SelfBlocked = false;
            await _repository.SaveChangesAsync();
        }
    }
}