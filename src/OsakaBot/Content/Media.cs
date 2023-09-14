using Osaka.Bot.Content;
using Telegram.Bot.Types;

namespace Osaka.Bot.Content;

public class Media
{
    public int MediaId { get; set; }
    public MediaType MediaType { get; set; }
    public string? FileId { get; set; } = null!;
    public string? FileUniqueId { get; set; } = null!;
    public string? Path { get; set; }
    public string? BotName { get; set; }

    public ICollection<InnerMessage>? InnerMessages { get; set; }
    public ICollection<ShowedMessage>? ShowedMessages { get; set; }

    public Media(MediaType mediaType, string? fileId = null, string? fileUniqueId = null, string? path = null)
    {
        MediaType = mediaType;
        FileId = fileId;
        FileUniqueId = fileUniqueId;
        Path = path;
    }
}