using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow;

public class ChatFlowService : IChatFlowService
{
    public Task<UserState> SubmitCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        //  check for data existanse 
        //      or await for dialogue respone
        //  make effects happen
        throw new NotImplementedException();
    }

    public Task<UserState> SubmitMessageAsync(Message message)
    {
        //  check for replybuttons
        //  validate
        //  dialogue fill
        //  effects
        throw new NotImplementedException();
    }
}