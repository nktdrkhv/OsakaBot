using Telegram.Bot.Types;

namespace Osaka.Bot.Abstract;

public interface ITelegramSubmitter
{
    ValueTask<InnerUserState> SubmitCallbackQueryAsync(CallbackQuery callbackQuery);
    ValueTask<InnerUserState> SubmitMessageAsync(Message message);
}