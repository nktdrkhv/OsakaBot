using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow.ChatScope;

public interface IChatScopeStorage
{
    ValueTask<ChatScope> CreateChatScope(User user);
    ValueTask<ChatScope> RetrieveChatScope(InnerUser user);
    ValueTask CommitChatScope(ChatScope chatScope);
}