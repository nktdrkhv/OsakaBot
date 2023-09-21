namespace Osaka.Bot.ChatFlow.ChatScope;

public interface IChatScopeService
{
    ValueTask<bool> HasCorrectionLoop(InnerUser user);
    ValueTask SetInputToReasonAsync(InnerUser user, Trigger trigger, InnerMessage message);
    ValueTask SetInputToCustomAsync(InnerUser user, InnerMessage message, Target target);
    ValueTask SetInputToActiveAsync(InnerUser user, InnerMessage message);
    ValueTask CleanScopeAsync(InnerUser user);
}