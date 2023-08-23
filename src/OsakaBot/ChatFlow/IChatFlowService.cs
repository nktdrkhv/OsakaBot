using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public interface IChatFlowService
{
    Task<UserState> SubmitCallbackQueryAsync(CallbackQuery callbackQuery);
    Task<UserState> SubmitMessageAsync(Message message);
}