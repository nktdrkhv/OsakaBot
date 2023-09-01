using Osaka.Bot.Content;

namespace Osaka.Bot.Content;

public class Media
{
    public int MediaId { get; set; }
    public MediaType MediaType { get; set; }
    public string FileId { get; set; } = null!;
    public string FileUniqueId { get; set; } = null!;
    public string? Path { get; set; }

    public Media(MediaType mediaType, string fileId, string fileUniqueId, string? path = null)
    {
        MediaType = mediaType;
        FileId = fileId;
        FileUniqueId = fileUniqueId;
        Path = path;
    }
}