using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public interface IChatFlowService : ITelegramSubmitter
{
    ValueTask<InnerUserState> SubmitMediaGroupAsync(IEnumerable<Message> mediaGroup);
}