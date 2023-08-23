using Telegram.Bot.Types.Enums;

namespace Osaka.Bot.Validation;

public class MessageTypeValidation : ValidationBase
{
    private MessageType _messageType;
    public MessageTypeValidation(MessageType type) => _messageType = type;
}