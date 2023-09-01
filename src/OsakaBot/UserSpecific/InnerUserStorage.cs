using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

public class SqlInnerUserStorage : IInnerUserStorge
{
    private readonly BotDbContext _dbContext;

    public SqlInnerUserStorage(BotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<bool> IsInnerUserExist(User user) =>
        await _dbContext.InnerUsers.AnyAsync(iu => iu.TelegramUserId == user.Id);

    public async ValueTask<InnerUser> CreateInnerUser(User user)
    {
        var innerUser = new InnerUser(user);
        await _dbContext.InnerUsers.AddAsync(innerUser);
        await _dbContext.SaveChangesAsync();
        return innerUser;
    }

    public async ValueTask<InnerUser> RetrieveInnerUser(User user) =>
        await _dbContext.InnerUsers.AsNoTracking().SingleAsync(iu => iu.TelegramUserId == user.Id);

    public async ValueTask CommitInnerUser(InnerUser user)
    {
        _dbContext.InnerUsers.Attach(user);
        await _dbContext.SaveChangesAsync();
    }
}