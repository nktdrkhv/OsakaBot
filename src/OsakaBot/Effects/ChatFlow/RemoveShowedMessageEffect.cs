using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveShowedMessageEffect : ChatChangingEffectBase
{
    [Column("WithUserInput")]
    public bool WithUserInput { get; private set; } = true;

    public RemoveShowedMessageEffect(Target target, bool withUserInput = true, byte order = 0) : base(EffectType.RemoveShowedMessage, order)
    {
        Target = target;
        WithUserInput = withUserInput;
    }

    private RemoveShowedMessageEffect() { }

    public override void SetArguments(object[] args) { }
}

public class RemoveShowedMessageEffectApplier : IEffectApplier<RemoveShowedMessageEffect>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IRepository _repository;

    public RemoveShowedMessageEffectApplier(ITelegramBotClient botClient, IRepository repository)
    {
        _botClient = botClient;
        _repository = repository;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveShowedMessageEffect)effect;
        var target = await _repository.GetByIdAsync<Target>(concrete.TargetId);
        if (await _repository.GetShowedMessageByTarget(concrete.User, target, true) is ShowedMessage showedMessage)
        {
            foreach (var id in showedMessage.ExtractMessageIds(
                    concrete.WithUserInput ? ExtractMessageIdsMode.Combine : ExtractMessageIdsMode.OnlyShowedMessage,
                    TimeSpan.FromDays(2)).OrderByDescending(x => x))
                await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, id);
        }
        else if (target.Type == TargetType.TelegramMessage)
            await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, target.MessageId!.Value);
    }
}