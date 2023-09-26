using System.Collections.Concurrent;
using System.Net.Http.Headers;
using SQLitePCL;
using TelegramUpdater;
using TelegramUpdater.Hosting;

namespace Osaka.Bot.Services;

public class UserStateKeeperAccessor : BackgroundService
{
    public const string Regular = "Regular";
    public const string Support = "Support";
    public const string Admin = "Admin";

    private readonly ConcurrentDictionary<long, (string KeeperName, long LastUnixTimeActivity)> _timeKeeperByUserId = new();
    private readonly IUpdater _updater;
    private readonly PeriodicTimer _timer;
    private readonly long _maxDeltaRegular = 3600L;
    private readonly long _maxDeltaCrew = 86400L;

    public UserStateKeeperAccessor(IUpdater updater)
    {
        _updater = updater;
        _timer = new PeriodicTimer(TimeSpan.FromMinutes(10));
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                var checkpoint = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                foreach (var userActivity in _timeKeeperByUserId)
                {
                    var hasToRemove = userActivity.Value.KeeperName switch
                    {
                        Regular => checkpoint - userActivity.Value.LastUnixTimeActivity > _maxDeltaRegular,
                        Support or Admin => checkpoint - userActivity.Value.LastUnixTimeActivity > _maxDeltaCrew,
                        _ => true
                    };
                    if (!hasToRemove)
                        continue;
                    if (_updater.TryGetUserNumericStateKeeper(userActivity.Value.KeeperName, out var stateKeeper))
                    {
                        stateKeeper.DeleteState(userActivity.Key);
                        _timeKeeperByUserId.TryRemove(userActivity.Key, out _);
                    }
                }
            }
            catch { }
        }
    }

    public void SetOrRenew(long telegramUserId, string? keeperName = null, int state = 0)
    {
        _ = _timeKeeperByUserId.AddOrUpdate(
            telegramUserId,
            userId =>
            {
                if (_updater.TryGetUserNumericStateKeeper(keeperName ?? Regular, out var stateKeeper))
                    stateKeeper.SetState(userId, state);
                return (keeperName ?? Regular, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            },
            (userId, oldValue) =>
            {
                if (keeperName == null || string.Equals(oldValue.KeeperName, keeperName))
                {
                    return (oldValue.KeeperName, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                }
                else
                {
                    if (_updater.TryGetUserNumericStateKeeper(oldValue.KeeperName, out var oldStateKeeper))
                        oldStateKeeper.DeleteState(userId);
                    if (_updater.TryGetUserNumericStateKeeper(keeperName, out var newStateKeeper))
                        newStateKeeper.SetState(userId, state);
                    return (keeperName, DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                }
            }
            );
    }
}