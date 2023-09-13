using System.Linq.Dynamic.Core;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Telegram.Bot.Types;

namespace Osaka.Bot.Extensions;

public static class RepositoryExtensions
{
    public static async ValueTask<InnerUser> GetInnerUser(this IRepository repo, User user, bool ant = false, CancellationToken ct = default) =>
        await repo.GetAsync<InnerUser>(iu => iu.TelegramUserId == user.Id, ant, cancellationToken: ct);

    public static async ValueTask<ChatScope> GetChatScope(this IRepository repo, InnerUser innerUser, bool includeAll = false, bool ant = false, CancellationToken ct = default)
    {
        Func<IQueryable<ChatScope>, IIncludableQueryable<ChatScope, object>> includes;
        if (includeAll)
        {
            includes = cs => cs
                .Include(cs => cs.InnerUser!)
                .Include(cs => cs.ShowedMessages!)
                .Include(cs => cs.PlainTriggers!)
                .Include(cs => cs.EncodedTriggers!)
                .Include(cs => cs.Validators!);
        }
        else
        {
            includes = cs => cs
                .Include(cs => cs.InnerUser!)
                .Include(cs => cs.ShowedMessages!)
                .Include(cs => cs.PlainTriggers!)
                .Include(cs => cs.EncodedTriggers!)
                .Include(cs => cs.Validators!)
                .Include(cs => cs.ActiveInput!)
                .Include(cs => cs.OnInvalidInput!)
                .Include(cs => cs.OnValidInput!)
                .Include(cs => cs.OnClearScope!);
        }
        return await repo.GetAsync(cs => cs.InnerUserId == innerUser.InnerUserId, includes, asNoTracking: ant, cancellationToken: ct);
    }

    public static async ValueTask SetUserInput(this IRepository repo, InnerUser innerUser, InnerMessage innerUserInput, Trigger? reasonTrigger = null, CancellationToken ct = default)
    {
        if (reasonTrigger is null)
        {
            var scope = await repo.GetAsync<ChatScope>(cs => cs.InnerUserId == innerUser.InnerUserId,
                cs => cs.Include(cs => cs.ActiveInput)
                            .ThenInclude(ai => ai!.RecievedFromUser),
                asNoTracking: false, cancellationToken: ct);
            if (scope.ActiveInput is not null)
                scope.ActiveInput.RecievedFromUser!.Add(innerUserInput);
        }
        else
        {
            var scope = await repo.GetAsync<ChatScope>(cs => cs.InnerUserId == innerUser.InnerUserId,
                cs => cs.Include(cs => cs.PlainTriggers!)
                            .ThenInclude(akt => akt.ShowedMessage)
                                .ThenInclude(sm => sm.RecievedFromUser),
                asNoTracking: false, cancellationToken: ct);
            scope.PlainTriggers!.First(akt => akt.TriggerId == reasonTrigger.TriggerId).ShowedMessage.RecievedFromUser!.Add(innerUserInput);
        }
    }

    public static async ValueTask<ICollection<ValidatorBase>?> GetValidators(this IRepository repo, InnerUser innerUser, bool ant = true, CancellationToken ct = default)
    {
        var scope = await repo.GetAsync<ChatScope>(
            sc => sc.InnerUserId == innerUser.InnerUserId,
            sc => sc.Include(sc => sc.Validators),
            asNoTracking: ant, cancellationToken: ct);
        return scope.Validators;
    }

    public static async ValueTask<string?> GetPostMeta(this IRepository repo, int postId, CancellationToken ct = default) =>
        await repo.GetQueryable<Post>()
            .AsNoTracking()
            .Where(p => p.PostId == postId)
            .Select(p => p.MetaMark)
            .FirstAsync(ct);

    public static async ValueTask<string?> GetContentMeta(this IRepository repo, int userId, int triggerId, CancellationToken ct = default) =>
        await repo.GetQueryable<ActiveKeyboardTrigger>()
            .AsNoTracking()
            .Include(akt => akt.ChatScope)
            .Include(akt => akt.ShowedMessage)
                .ThenInclude(sm => sm.InnerMessage)
            .Where(akt => akt.ChatScope.InnerUserId == userId && akt.TriggerId == triggerId)
            .Select((akt, _) => akt.ShowedMessage.InnerMessage!.MetaMark)
            .FirstAsync(ct);

    public static async ValueTask<string?> GetButtonMeta(this IRepository repo, int triggerId, CancellationToken ct = default) =>
        await repo.GetQueryable<ButtonBase>()
            .AsNoTracking()
            .Where(b => b.TriggerId == triggerId)
            .Select(b => b.MetaMark)
            .FirstAsync(ct);

    public static async ValueTask<Text> GetButtonText(this IRepository repo, int triggerId, CancellationToken ct = default) =>
        await repo.GetQueryable<ButtonBase>()
            .AsNoTracking()
            .Include(b => b.Text)
                .ThenInclude(t => t.Surrogates)
            .Where(b => b.TriggerId == triggerId)
            .Select(b => b.Text)
            .FirstAsync(ct);
}