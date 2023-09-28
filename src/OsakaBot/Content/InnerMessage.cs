using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Osaka.Bot.Content;

[Table("InnerMessage")]
public class InnerMessage : ITitled, IMetaMark, IIdsKeeper
{
    public int InnerMessageId { get; set; }
    public InnerMessageType Type { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CauseMessageId { get; set; }
    public int[]? CauseMessagesIds { get; set; }
    public string? MediaGroupId { get; set; }

    public string? Title { get; set; }
    public string? MetaMark { get; set; }

    public int? TextId { get; set; }
    public Text? Text { get; set; }
    public ICollection<Media>? Media { get; set; }

    public int? ContactId { get; set; }
    public InnerContact? Contact { get; set; }

    public int? GeolocationId { get; set; }
    public Geolocation? Geolocation { get; set; }

    public ICollection<ShowedMessage>? ShowingBy { get; set; }
    public ICollection<ShowedMessage>? SentByUser { get; set; }

    public InnerMessage() { }

    public InnerMessage(int causeMessageId, Text textItself, bool buttonOrigin = false)
    {
        CauseMessageId = causeMessageId;
        Text = textItself;
        Type = buttonOrigin ? InnerMessageType.TextFromButton : InnerMessageType.Text;
    }

    public InnerMessage(Message message)
    {
        CauseMessageId = message.MessageId;
        switch (message.Type)
        {
            case MessageType.Text:
                Type = InnerMessageType.Text;
                Text = new(message.Text!, message.Entities);
                break;
            case MessageType.Photo:
                Type = InnerMessageType.Photo;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            case MessageType.Audio:
                Type = InnerMessageType.Audio;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            case MessageType.Video:
                Type = InnerMessageType.Video;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            case MessageType.Voice:
                Type = InnerMessageType.Voice;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            case MessageType.Document:
                Type = InnerMessageType.Document;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            case MessageType.Sticker:
                Type = InnerMessageType.Sticker;
                Media = new Media[] { new(message) };
                break;
            case MessageType.Contact:
                Type = InnerMessageType.Contact;
                Contact = new InnerContact(message.Contact!);
                break;
            case MessageType.Location:
                Type = InnerMessageType.Geolocation;
                Geolocation = new Geolocation(message.Location!.Longitude, message.Location.Latitude);
                break;
            case MessageType.Venue:
                Type = InnerMessageType.Geolocation;
                Geolocation = new Geolocation(message.Venue!.Location.Longitude, message.Venue.Location.Latitude, message.Venue.Title, message.Venue.Address);
                break;
            case MessageType.VideoNote:
                Type = InnerMessageType.VideoNote;
                Media = new Media[] { new(message) };
                break;
            case MessageType.Animation:
                Type = InnerMessageType.Animation;
                Media = new Media[] { new(message) };
                Text = message.Caption != null ? new(message.Caption!, message.Entities) : null;
                break;
            default:
                Type = InnerMessageType.Unsupported;
                break;
        };
    }

    public InnerMessage(IEnumerable<Message> messages)
    {
        var first = messages.First();
        CauseMessageId = first.MessageId;
        MediaGroupId = first.MediaGroupId!;
        Type = first.Type switch
        {
            MessageType.Photo => InnerMessageType.PhotoVideoAlbum,
            MessageType.Video => InnerMessageType.PhotoVideoAlbum,
            MessageType.Audio => InnerMessageType.AudioAlbum,
            MessageType.Document => InnerMessageType.DocumentAlbum,
            _ => InnerMessageType.Unsupported
        };
        Text = first.Caption != null ? new(first.Caption!, first.Entities) : null;
        var ids = new List<int>();
        Media = new List<Media>();
        foreach (var msg in messages)
            if (MediaGroupId == msg.MediaGroupId)
            {
                var singleMedia = msg.Type switch
                {
                    MessageType.Photo => new Media(msg),
                    MessageType.Video => new Media(msg),
                    MessageType.Audio => new Media(msg),
                    MessageType.Document => new Media(msg),
                    _ => throw new ArgumentException($"One of MediaGroups messagies doesn't fit: {msg.Type}")
                };
                Media.Add(singleMedia);
                ids.Add(msg.MessageId);
            }
        CauseMessagesIds = ids.ToArray();
    }
}