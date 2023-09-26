using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ActiveKeyboardTrigger")]
public class ActiveKeyboardTrigger
{
    public int ActiveKeyboardTriggerId { get; private set; }
    public string Text { get; protected set; } = null!;

    public int TriggerId { get; private set; }
    public Trigger Trigger { get; private set; } = null!;

    public int ChatScopeId { get; private set; }
    public ChatScope ChatScope { get; private set; } = null!;

    public int ShowedMessageId { get; private set; }
    public ShowedMessage ShowedMessage { get; private set; } = null!;

    public ActiveKeyboardTrigger(string text, Trigger trigger) => (Text, Trigger) = (text, trigger);
    protected ActiveKeyboardTrigger() { }

    public void SetScope(ChatScope chatScope, ShowedMessage showedMessage) => (ChatScope, ShowedMessage) = (chatScope, showedMessage);
}