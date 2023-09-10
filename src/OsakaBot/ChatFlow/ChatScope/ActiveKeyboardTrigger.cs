using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ActiveKeyboardTrigger")]
public class ActiveKeyboardTrigger : ILabeled
{
    public int ActiveKeyboardTriggerId { get; set; }
    public string? Label { get; set; } = null!;
    public int TriggerId { get; set; }
    public Trigger Trigger { get; set; } = null!;
}