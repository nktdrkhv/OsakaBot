namespace Osaka.Bot.InputSystem;

public interface IInputService
{
    ValueTask FromButtonTriggerAsync(InnerUser user, Trigger trigger);
    ValueTask FromButtonTriggerAsync(InnerUser user, Trigger trigger, string text);
    ValueTask FromMessageTriggerAsync(InnerUser user, Trigger trigger, InnerMessage message);
}