namespace Osaka.Bot.Content;

public interface ITextSetterDispatcher
{
    Task<string> ResolveAsync<T>(T setter) where T : TextSetterBase;
}