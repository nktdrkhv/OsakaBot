namespace Osaka.Bot.Configuration;

public class BotConfiguration
{
    public static readonly string Section = "BotConfiguration";

    public string BotName { get; set; } = null!;
    public string BotToken { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public bool IsTestEnv { get; set; }
}