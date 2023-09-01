using Telegram.Bot.Types;

namespace Osaka.Bot.ChatFlow.ChatScope;

public class SqlChatScopeStorage : IChatScopeStorage
{
    private readonly BotDbContext _botDbContext;

    public SqlChatScopeStorage(BotDbContext botDbContext)
    {
        _botDbContext = botDbContext;
    }

    public ValueTask<ChatScope> CreateChatScope(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ChatScope> RetrieveChatScope(InnerUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask CommitChatScope(ChatScope chatScope)
    {
        throw new NotImplementedException();
    }
}

// public class CacheChatScopeStorageDecorator : IChatScopeStorage
// {
//     public ValueTask<ChatScope> CreateChatScope(User user)
//     {
//         throw new NotImplementedException();
//     }

//     public ValueTask<ChatScope> RetrieveChatScope(InnerUser user)
//     {
//         throw new NotImplementedException();
//     }

//     public ValueTask CommitChatScope(ChatScope chatScope)
//     {
//         throw new NotImplementedException();
//     }
// }