namespace Osaka.Bot.ChatFlow.ChatScope;

public interface IChatScopeService
{
    ValueTask<bool> IsTriggerInTheScopeAsync(InnerUser user, Trigger trigger);
    // clear scope
}