namespace Osaka.Bot.Dialogue;

public interface IDialogeService
{
    ValueTask<bool> IsThereAnyActiveDialogue(InnerUser user);
    ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger);
    ValueTask AssignFromTriggerAsync(InnerUser user, Trigger trigger, InnerMessage message);
}