namespace Osaka.Bot.ChatFlow.ChatScope;

public interface IChatScopeService
{
    //ValueTask<Post?> GetActiveInputReasonAsync(InnerUser user);
    ValueTask<bool> HasCorrectionLoop(InnerUser user);
    ValueTask SetInputToReasonAsync(InnerUser user, Trigger trigger, InnerMessage message);
    ValueTask SetInputToActiveAsync(InnerUser user, InnerMessage message);
    ValueTask CleanScopeAsync(InnerUser user);
}