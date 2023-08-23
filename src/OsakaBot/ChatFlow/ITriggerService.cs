namespace Osaka.Bot.ChatFlow;

public interface ITriggerService
{
    Task<Trigger> FromEncoded(string encodedId);
}