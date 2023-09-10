using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public interface IChatFlowService : ITelegramSubmitter
{
    ValueTask SubmitMediaGroupAsync(IEnumerable<Message> mediaGroup);
}