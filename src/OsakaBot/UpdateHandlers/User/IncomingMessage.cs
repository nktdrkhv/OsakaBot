using System.Diagnostics.Eventing.Reader;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramUpdater;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.Scoped;
using TelegramUpdater.UpdateHandlers.Scoped.ReadyToUse;

namespace Osaka.Bot.UpdateHandlers.User.Messages;

[UserNumericState(UserStateKeeperAccessor.Regular, 0), Order(6)]
public sealed class IncomingMessage : MessageHandler
{
    private readonly IChatFlowService _chatFlow;

    public IncomingMessage(IChatFlowService chatFlow) => _chatFlow = chatFlow;

    protected async override Task HandleAsync(IContainer<Message> cntr)
    {
        if (cntr.Update.MediaGroupId is string mediaGroup)
        {
            var album = new List<Message> { cntr.Update };
            for (byte i = 0; i < 9; i++)
            {
                var newMsg = await AwaitMessageAsync(
                    FilterCutify.When<Message>((updater, message) => string.Equals(mediaGroup, message.MediaGroupId)),
                    TimeSpan.FromSeconds(1));
                if (newMsg != null)
                    album.Add(newMsg.Update);
                else
                    break;
            }
            await _chatFlow.SubmitMediaGroupAsync(album);
        }
        else if (cntr.Update.Text?.Trim() is string text && text[0] == '/')
        {

        }
        else
            await _chatFlow.SubmitMessageAsync(cntr.Update);
    }
}