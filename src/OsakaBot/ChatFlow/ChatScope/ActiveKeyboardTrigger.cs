namespace Osaka.Bot.ChatFlow.ChatScope;

public class ActiveKeyboardTrigger
{
    public string CustomLabel { get; set; } = null!;
    public ShowedMessage Reason { get; set; } = null!;
    public Trigger TriggerItself { get; set; } = null!;
}