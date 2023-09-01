using System.Threading.Tasks.Sources;

namespace Osaka.Bot.ChatFlow;

public interface ITriggerService
{
    ValueTask ExecuteAsync(InnerUser user, Trigger trigger);
    ValueTask ExecuteAsync(InnerUser user, EffectBase effect);
    ValueTask<Trigger?> FromValidCustomInput(InnerUser user);
    ValueTask<Trigger?> FromInvalidCustomInput(InnerUser user);
    ValueTask<Trigger?> FromPlainPreparedAsync(InnerUser user, string prepared);
    ValueTask<Trigger?> FromEncodedPreparedAsync(InnerUser user, string encodedId);
    ValueTask<Trigger?> FromEncodedStoredAsync(InnerUser user, string encodedId);
    string IntoEncodedId(InnerUser user, Trigger trigger);
}