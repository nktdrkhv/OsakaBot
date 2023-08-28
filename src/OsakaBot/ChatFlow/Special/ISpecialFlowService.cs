namespace Osaka.Bot.ChatFlow.Special;

public interface ISpecialFlowService : ITelegramSubmitter
{
    ValueTask<InnerUserState> DisplayAsync();
}