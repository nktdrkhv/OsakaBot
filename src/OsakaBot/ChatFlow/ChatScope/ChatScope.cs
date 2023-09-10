using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

public class ChatScope
{
    public int ChatScopeId { get; set; }
    public int InnerUserId { get; set; }
    public InnerUser InnerUser { get; set; } = null!;
    public string? Named { get; set; }

    public ICollection<ShowedMessage> ShowedMessages { get; set; } = null!;
    public ICollection<ActiveKeyboardTrigger>? PlainTriggers { get; set; }
    public ICollection<ActiveKeyboardTrigger>? EncodedTriggers { get; set; }
    public ICollection<ValidatorBase>? Validators { get; set; }

    public int ActiveInputId { get; set; }
    public int OnValidInputId { get; set; }
    public int OnInvalidInputId { get; set; }
    public int OnClearScopeId { get; set; }

    public ShowedMessage? ActiveInput { get; set; }
    public Trigger? OnValidInput { get; set; }
    public Trigger? OnInvalidInput { get; set; }
    public Trigger? OnClearScope { get; set; }

    public bool HasToRedirectInvalidInput { get; set; } = false;
}