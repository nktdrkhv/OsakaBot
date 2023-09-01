namespace Osaka.Bot.ChatFlow;

public interface ITriggerStorage
{
    ValueTask<Trigger?> RetrieveTrigger(int triggerId);
}