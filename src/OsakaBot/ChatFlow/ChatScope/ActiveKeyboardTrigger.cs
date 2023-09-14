using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ActiveKeyboardTrigger")]
public class ActiveKeyboardTrigger
{
    public int ActiveKeyboardTriggerId { get; set; }
    public string Text { get; set; } = null!;

    public int ChatScopeId { get; set; }
    public ChatScope ChatScope { get; set; } = null!;

    public int ShowedMessageId { get; set; }
    public ShowedMessage ShowedMessage { get; set; } = null!;

    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; } = null!;
}