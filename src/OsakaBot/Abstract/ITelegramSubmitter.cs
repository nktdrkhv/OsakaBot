using Telegram.Bot.Types;

namespace Osaka.Bot.Abstract;

public interface ITelegramSubmitter
{
    ValueTask SubmitCommandAsync(string command);
    ValueTask SubmitCallbackQueryAsync(CallbackQuery callbackQuery);
    ValueTask SubmitMessageAsync(Message message);
}