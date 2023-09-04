namespace Osaka.Bot.InputSystem;

public interface IInputService
{
    ValueTask<bool> IsThereAnyActiveDialogue(InnerUser user);
    ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger);
    ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger, InnerMessage message);
    ValueTask AssignFromConcreteMessage(InnerUser user, int messageId, string data);
}