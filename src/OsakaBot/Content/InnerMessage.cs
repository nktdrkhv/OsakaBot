using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Osaka.Bot.Content;

public class InnerMessage
{
    public int InnerMessageId { get; set; }
    public InnerMessageType Type { get; set; }
    public int? CauseMessageId { get; set; }
    public int[]? CauseMessagesIds { get; set; }
    public string? MediaGroupId { get; set; }
    public string? Label { get; set; }
    public Text? Text { get; set; }
    public InnerContact? Contact { get; set; }
    public Geolocation? Geolocation { get; set; }
    public ICollection<Media>? Media { get; set; }

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
                break;
            case MessageType.Photo:
                Type = InnerMessageType.Photo;
                var photo = message.Photo!.Last();
                var photoFileId = photo.FileId;
                var photoUniqueId = photo.FileUniqueId;
                Media = new Media[] { new(MediaType.Photo, photoFileId, photoUniqueId) };
                break;
            case MessageType.Audio:
                Type = InnerMessageType.Audio;
                var audioFileId = message.Audio!.FileId;
                var audioUniqueId = message.Audio!.FileUniqueId;
                Media = new Media[] { new(MediaType.Audio, audioFileId, audioUniqueId) };
                break;
            case MessageType.Video:
                Type = InnerMessageType.Video;
                var videoFileId = message.Video!.FileId;
                var videoUniqueId = message.Video!.FileUniqueId;
                Media = new Media[] { new(MediaType.Video, videoUniqueId, videoUniqueId) };
                break;
            case MessageType.Voice:
                Type = InnerMessageType.Voice;
                var voiceFileId = message.Voice!.FileId;
                var voiceUniqueId = message.Voice!.FileUniqueId;
                Media = new Media[] { new(MediaType.Voice, voiceFileId, voiceUniqueId) };
                break;
            case MessageType.Document:
                Type = InnerMessageType.Document;
                var documentFileId = message.Document!.FileId;
                var documentUniqueId = message.Document!.FileUniqueId;
                Media = new Media[] { new(MediaType.Photo, documentFileId, documentUniqueId) };
                break;
            case MessageType.Sticker:
                Type = InnerMessageType.Sticker;
                var stickerFileId = message.Sticker!.FileId;
                var stickerUniqueId = message.Sticker!.FileUniqueId;
                Media = new Media[] { new(MediaType.Photo, stickerFileId, stickerUniqueId) };
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
                var videoNoteFileId = message.VideoNote!.FileId;
                var videoNoteUniqueId = message.VideoNote!.FileUniqueId;
                Media = new Media[] { new(MediaType.Photo, videoNoteFileId, videoNoteUniqueId) };
                break;
            case MessageType.Animation:
                Type = InnerMessageType.Animation;
                var aniFileId = message.Animation!.FileId;
                var aniUniqueId = message.Animation!.FileUniqueId;
                Media = new Media[] { new(MediaType.Photo, aniFileId, aniUniqueId) };
                break;
            default:
                Type = InnerMessageType.Unsupported;
                break;
        };
    }

    public InnerMessage(IEnumerable<Message> messages)
    {
        var first = messages.First();
        MediaGroupId = first.MediaGroupId!;
        Type = first.Type switch
        {
            MessageType.Photo => InnerMessageType.PhotoVideoAlbum,
            MessageType.Video => InnerMessageType.PhotoVideoAlbum,
            MessageType.Audio => InnerMessageType.AudioAlbum,
            MessageType.Document => InnerMessageType.DocumentAlbum,
            _ => InnerMessageType.Unsupported
        };
        var ids = new List<int>();
        Media = new List<Media>();
        foreach (var msg in messages)
            if (MediaGroupId == msg.MediaGroupId)
            {
                var singleMedia = msg.Type switch
                {
                    MessageType.Photo => new Media(MediaType.Photo, msg.Photo!.Last().FileId, msg.Photo!.Last().FileUniqueId),
                    MessageType.Video => new Media(MediaType.Video, msg.Video!.FileId, msg.Video.FileUniqueId),
                    MessageType.Audio => new Media(MediaType.Audio, msg.Audio!.FileId, msg.Audio.FileUniqueId),
                    MessageType.Document => new Media(MediaType.Document, msg.Document!.FileId, msg.Document.FileUniqueId),
                    _ => throw new Exception()
                };
                Media.Add(singleMedia);
                ids.Add(msg.MessageId);
            }
        CauseMessagesIds = ids.ToArray();
    }
}