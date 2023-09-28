using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveUserInputEffect : ChatChangingEffectBase
{
    public RemoveUserInputOptions Options { get; private set; } = RemoveUserInputOptions.All;

    public RemoveUserInputEffect(Target target, RemoveUserInputOptions options, byte order = 0) : base(EffectType.RemoveUserInput, order)
    {
        Target = target;
        Options = options;
    }

    private RemoveUserInputEffect() { }

    public override void SetArguments(object[] args) { }
}

public class RemoveUserInputEffectApplier : IEffectApplier<RemoveUserInputEffect>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IRepository _repository;

    public RemoveUserInputEffectApplier(ITelegramBotClient botClient, IRepository repository)
    {
        _botClient = botClient;
        _repository = repository;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveUserInputEffect)effect;
        var target = await _repository.GetByIdAsync<Target>(concrete.TargetId);
        if (await _repository.GetShowedMessageByTarget(concrete.User, target, true) is ShowedMessage showedMessage)
        {
            switch (concrete.Options)
            {
                case RemoveUserInputOptions.LastOne:
                    var lastId = showedMessage.ExtractMessageIds(ExtractMessageIdsMode.OnlyRecievedMessages, TimeSpan.FromDays(2)).Max();
                    await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, lastId);
                    break;
                case RemoveUserInputOptions.All:
                    foreach (var id in showedMessage.ExtractMessageIds(ExtractMessageIdsMode.OnlyRecievedMessages, TimeSpan.FromDays(2)).OrderByDescending(x => x))
                        await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, id);
                    break;
            }
        }
    }
}