using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveShowedMessageEffect : ChatChangingEffectBase
{
    [Column("WithUserInput")]
    public bool WithUserInput { get; private set; } = true;

    public int? ShowedMessageId { get; private set; }
    public ShowedMessage? ShowedMessage { get; private set; }

    public RemoveShowedMessageEffect(Target target, bool withUserInput = true, byte order = 0) : base(EffectType.RemoveShowedMessage, order)
    {
        Target = target;
        WithUserInput = withUserInput;
    }

    public RemoveShowedMessageEffect(ShowedMessage showedMessage, bool withUserInput = true, byte order = 0) : base(EffectType.RemoveShowedMessage, order)
    {
        ShowedMessage = showedMessage;
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
        if ((concrete.ShowedMessage ??
            await _repository.GetShowedMessageByTarget(concrete.User, target, true))
            is ShowedMessage showedMessage)
        {
            var ids = showedMessage.ExtractMessageIds(
                    concrete.WithUserInput ? ExtractMessageIdsMode.Combine : ExtractMessageIdsMode.OnlyShowedMessage,
                    TimeSpan.FromDays(2));
            foreach (var id in ids.OrderByDescending(x => x))
                await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, id);
        }
        else if (target.Type == TargetType.TelegramMessage)
            await _botClient.DeleteMessageAsync(concrete.User.TelegramUserId, target.MessageId!.Value);
    }
}

// var scope = await _repository.GetUserScope(concrete.User);
//             if (scope.PlainTriggers!.Count > 0)
//             {
//                 var plainMatches = scope.PlainTriggers.Where(akt => ids.Contains(akt.ShowedMessageId));
// scope.PlainTriggers = scope.PlainTriggers.Except(plainMatches).ToArray();
//             }
//             if (scope.EncodedTriggers!.Count > 0)
// {
//     var encodedMatches = scope.EncodedTriggers.Where(akt => ids.Contains(akt.ShowedMessageId));
//     scope.EncodedTriggers = scope.PlainTriggers.Except(encodedMatches).ToArray();
// }