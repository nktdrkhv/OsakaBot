using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

public class InnerUserStorage : IInnerUserStorge
{
    public ValueTask CommitInnerUser(InnerUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InnerUser> CreateInnerUser(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> IsInnerUserExist(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<InnerUser> RetrieveInnerUser(User user)
    {
        throw new NotImplementedException();
    }
}