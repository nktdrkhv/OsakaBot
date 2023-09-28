using Telegram.Bot;

namespace Osaka.Bot.Effects.ChatFlow;

public sealed class RemoveInlineKeyboardEffect : ChatChangingEffectBase
{
    public RemoveInlineKeyboardEffect(Target target, byte order = 0) : base(EffectType.RemoveInlineKeyboard, order)
        => Target = target;

    private RemoveInlineKeyboardEffect() { }

    public override void SetArguments(object[] args) { }
}

public class RemoveInlineKeyboardEffectApplier : IEffectApplier<RemoveInlineKeyboardEffect>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IRepository _repository;

    public RemoveInlineKeyboardEffectApplier(ITelegramBotClient botClient, IRepository repository)
    {
        _botClient = botClient;
        _repository = repository;
    }

    public async ValueTask Apply(EffectBase effect)
    {
        var concrete = (RemoveInlineKeyboardEffect)effect;
        var target = await _repository.GetByIdAsync<Target>(concrete.TargetId);
        if (target.Type == TargetType.TelegramMessage)
            // todo: remove related activekeyboardtriggers
            await _botClient.EditMessageReplyMarkupAsync(
                concrete.User.TelegramUserId,
                target.MessageId!.Value
            );
        else
        {
            var showedMessage = await _repository.GetShowedMessageByTarget(concrete.User, concrete.Target!);
            await _botClient.EditMessageReplyMarkupAsync(
                concrete.User.TelegramUserId,
                showedMessage.CauseMessageId
            );
        }
    }
}