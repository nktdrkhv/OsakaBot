using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ShowedMessage")]
public class ShowedMessage : ILabeled, IIdsKeeper
{
    public int ShowedMessageId { get; set; }
    public InnerMessageType Type { get; set; }
    public string? Label { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CauseMessageId { get; set; }
    public int[]? CauseMessagesIds { get; set; }

    public int? TextId { get; set; }
    public Text? Text { get; set; }
    public ICollection<Media>? Media { get; set; }

    public int ChatScopeId { get; set; }
    public ChatScope ChatScope { get; set; } = null!;

    public int? PostId { get; set; }
    public Post? Post { get; set; }

    public int? InnerMessageId { get; set; }
    public InnerMessage? InnerMessage { get; set; }

    public ICollection<InnerMessage>? RecievedFromUser { get; set; }
    public ICollection<ActiveKeyboardTrigger>? RelatedTriggers { get; set; }

    public ICollection<int> ExtractMessageIds(ExtractMessageIdsMode mode, TimeSpan? noOlderThen)
    {
        var ids = new List<int>();
        switch (mode)
        {
            case ExtractMessageIdsMode.OnlyShowedMessage:
                ids.AddRange(((IIdsKeeper)this).ExtractIds(noOlderThen));
                break;
            case ExtractMessageIdsMode.OnlyRecievedMessages:
                foreach (var elem in RecievedFromUser!.Cast<IIdsKeeper>())
                    ids.AddRange(elem!.ExtractIds(noOlderThen));
                break;
            case ExtractMessageIdsMode.Combine:
                ids.AddRange(((IIdsKeeper)this).ExtractIds(noOlderThen));
                foreach (var elem in RecievedFromUser!.Cast<IIdsKeeper>())
                    ids.AddRange(elem!.ExtractIds(noOlderThen));
                break;
        }
        return ids;
    }
}