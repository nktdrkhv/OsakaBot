using System.Linq.Dynamic.Core;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Telegram.Bot.Types;

namespace Osaka.Bot.Extensions;

public static class RepositoryExtensions
{
    // public static IQueryable<ChatScope> GetUserScopeQuery(this IRepository repo, InnerUser user) => repo.GetQueryable<ChatScope>().Where(cs => cs.InnerUserId == user.InnerUserId);

    public static async ValueTask<InnerUser> GetInnerUser(this IRepository repo, User user, bool ant = false, CancellationToken ct = default) =>
        await repo.GetAsync<InnerUser>(iu => iu.TelegramUserId == user.Id, ant, cancellationToken: ct);

    public static async ValueTask<ChatScope> GetUserScope(this IRepository repo, InnerUser innerUser, bool includeAll = false, bool ant = false, CancellationToken ct = default)
    {
        return await repo.GetAsync<ChatScope>(cs => cs.InnerUserId == innerUser.InnerUserId,
        cs => cs
            .AsSplitQuery()
            .Include(cs => cs.InnerUser!)
            .Include(cs => cs.ShowedMessages!)
            .Include(cs => cs.PlainTriggers!)
            .Include(cs => cs.EncodedTriggers!)
            .Include(cs => cs.Validators!)
            .Include(cs => cs.ActiveInput!)
            .Include(cs => cs.OnInvalidInput!)
            .Include(cs => cs.OnValidInput!)
            .Include(cs => cs.OnScopeClean!)
                .ThenInclude(t => t.Effects),
            asNoTracking: ant, cancellationToken: ct);
    }

    public static async ValueTask SetUserInput(this IRepository repo, InnerUser innerUser, InnerMessage innerUserInput, CancellationToken ct = default)
    {

        var scope = await repo.GetAsync<ChatScope>(
            cs => cs.InnerUserId == innerUser.InnerUserId,
            cs => cs.Include(cs => cs.ActiveInput)
                        .ThenInclude(ai => ai!.RecievedFromUser),
            asNoTracking: false, cancellationToken: ct);
        if (scope.ActiveInput is not null)
            scope.ActiveInput.RecievedFromUser!.Add(innerUserInput);

        await repo.SaveChangesAsync();
    }

    public static async ValueTask SetUserInput(this IRepository repo, InnerUser innerUser, InnerMessage innerUserInput, Trigger reasonTrigger, CancellationToken ct = default)
    {

        var scope = await repo.GetAsync<ChatScope>(
            cs => cs.InnerUserId == innerUser.InnerUserId,
            cs => cs.Include(cs => cs.PlainTriggers!)
                        .ThenInclude(akt => akt.ShowedMessage)
                            .ThenInclude(sm => sm.RecievedFromUser),
            asNoTracking: false, cancellationToken: ct);
        scope.PlainTriggers!.First(akt => akt.TriggerId == reasonTrigger.TriggerId).ShowedMessage.RecievedFromUser!.Add(innerUserInput);
        await repo.SaveChangesAsync();
    }

    public static async ValueTask SetUserInput(this IRepository repo, InnerUser innerUser, InnerMessage innerUserInput, Target target, CancellationToken ct = default)
    {
        await ValueTask.CompletedTask;
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
            .AsSplitQuery()
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
                .ThenInclude(t => t.Surrogates!)
            .Where(b => b.TriggerId == triggerId)
            .Select(b => b.Text)
            .FirstAsync(ct);

    public static async ValueTask<Post> GetPost(this IRepository repo, int postId, bool ant = true, CancellationToken ct = default)
    {
        return await repo.GetByIdAsync<Post>(postId,
            p => p
                .AsSplitQuery()
                .Include(p => p.Content)
                    .ThenInclude(im => im.Media)
                .Include(p => p.Content)
                    .ThenInclude(im => im.Text)
                        .ThenInclude(t => t!.Surrogates!)
                .Include(p => p.Content)
                    .ThenInclude(im => im.Geolocation)
                .Include(p => p.Content)
                    .ThenInclude(im => im.Contact)
                .Include(p => p.RoleVisibility)
                .Include(p => p.Keyboard)
                .Include(p => p.UserInput)
                .Include(p => p.OnUserScopeClear),
                asNoTracking: ant, cancellationToken: ct);
    }
}