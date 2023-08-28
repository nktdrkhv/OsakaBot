using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.Abstract;

[Table("Message")]
public abstract class MessageBase
{
    [Key]
    public virtual int MessageId { get; set; }
    public virtual int CauseMessageId { get; set; }
    public virtual InnerMessageType Type { get; set; }
    public virtual string? Label { get; set; } = null!;
    public virtual Text? Text { get; set; }
    public virtual ICollection<Media>? Media { get; set; }
}