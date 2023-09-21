using Telegram.Bot.Types;

namespace Osaka.Bot.Abstract;

public interface ITelegramSubmitter
{
    ValueTask SubmitCommandAsync(Message message);
    ValueTask SubmitCallbackQueryAsync(CallbackQuery callbackQuery);
    ValueTask SubmitMessageAsync(Message message);
}