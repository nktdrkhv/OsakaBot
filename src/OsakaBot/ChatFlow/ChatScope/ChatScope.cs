namespace Osaka.Bot.ChatFlow.ChatScope;

public class ChatScope
{
    public int ChatScopeId { get; set; }
    public InnerUser InnerUser { get; set; } = null!;
    public ICollection<ShowedMessage> ShowedMessages { get; set; } = null!;
    public ICollection<ActiveKeyboardTrigger>? PreparedText { get; set; }
    public ICollection<ActiveKeyboardTrigger>? QueryData { get; set; }
    public Trigger? OnValidInput { get; set; }
    public Trigger? OnInvalidInput { get; set; }
    public Trigger? InClearScope { get; set; }
    public bool IsAnyActiveDialogue { get; set; } = false;
    public bool IsInvalidInputHappend { get; set; } = false;
}