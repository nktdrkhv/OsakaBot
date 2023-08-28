using Osaka.Bot.Content;

namespace Osaka.Bot.Content;

public class Media
{
    public int MediaId { get; set; }
    public string FileId { get; set; } = null!;
    public string FileUniqueId { get; set; } = null!;
    public MediaType MediaType { get; set; }
}