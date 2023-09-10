using Telegram.Bot.Types;

namespace Osaka.Bot.Abstract;

public interface ITelegramSubmitter
{
    ValueTask SubmitCallbackQueryAsync(CallbackQuery callbackQuery);
    ValueTask SubmitMessageAsync(Message message);
}