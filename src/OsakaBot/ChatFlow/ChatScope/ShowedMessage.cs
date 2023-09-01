namespace Osaka.Bot.ChatFlow.ChatScope;

public class ShowedMessage
{
    public int ShowedMessageId { get; set; }
    public int? CauseMessageId { get; set; }
    public InnerMessageType Type { get; set; }
    public string? Label { get; set; } = null!;
    public Text? Text { get; set; }
    public ICollection<Media>? Media { get; set; }
    public ICollection<InnerMessage>? RecievedFromUser { get; set; }
}