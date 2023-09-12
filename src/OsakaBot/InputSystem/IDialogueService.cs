namespace Osaka.Bot.InputSystem;

public interface IDialogueService
{
    ValueTask<bool> IsThereAnyActiveDialogueAsync(InnerUser user);
    ValueTask<ActiveIncludedPost?> RetrieveActiveIncludedPost(InnerUser user, Trigger trigger);
    ValueTask EnterDataAsync(InnerUser user, ActiveIncludedPost reason, string? textData = null, InnerMessage? messageData = null, bool rewrite = true);
    ValueTask EnterDataAsync(InnerUser user, ActualDialogue actualDialogue, Variable variable, string? textData = null, InnerMessage? messageData = null, bool rewrite = false);
}