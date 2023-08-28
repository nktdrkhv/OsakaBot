using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

public interface IInnerUserStorge
{
    ValueTask<bool> IsInnerUserExist(User user);
    ValueTask<InnerUser> CreateInnerUser(User user);
    ValueTask<InnerUser> RetrieveInnerUser(User user);
    ValueTask CommitInnerUser(InnerUser user);
}