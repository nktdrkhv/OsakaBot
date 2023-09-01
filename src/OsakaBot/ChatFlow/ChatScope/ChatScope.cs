using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

public class ChatScope
{
    public int ChatScopeId { get; set; }
    public InnerUser InnerUser { get; set; } = null!;
    public string? Named { get; set; }
    public ICollection<ShowedMessage> ShowedMessages { get; set; } = null!;
    public ICollection<ActiveKeyboardTrigger>? TriggerByPreparedPlain { get; set; }
    public ICollection<ActiveKeyboardTrigger>? TriggerByPreparedEncoded { get; set; }
    public ICollection<ValidatorBase>? Validators { get; set; }
    public ShowedMessage? ActiveInput { get; set; }
    public Trigger? OnValidInput { get; set; }
    public Trigger? OnInvalidInput { get; set; }
    public Trigger? OnClearScope { get; set; }
    //public bool IsAnyActiveDialogue { get; set; } = false;
    public bool HasToRedirectInvalidInput { get; set; } = false;
}