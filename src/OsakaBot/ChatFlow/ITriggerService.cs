using System.Threading.Tasks.Sources;

namespace Osaka.Bot.ChatFlow;

public interface ITriggerService
{
    ValueTask<Trigger?> FromCorrectCustomInput(InnerUser user);
    ValueTask<Trigger?> FromIncorrectCustomInput(InnerUser user);
    ValueTask<Trigger?> FromEncodedAsync(InnerUser user, string encodedId);
    ValueTask<Trigger?> FromPreparedAsync(InnerUser user, string prepared);
    ValueTask ExecuteAsync(InnerUser user, Trigger trigger);
}