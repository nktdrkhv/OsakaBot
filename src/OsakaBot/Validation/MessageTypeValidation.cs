namespace Osaka.Bot.Validation;

public class MessageTypeValidator : ValidatorBase
{
    public InnerMessageType Type { get; set; }

    public MessageTypeValidator(InnerMessageType type) => Type = type;

    public override bool Validate(InnerMessage message) => Invert ? Type != message.Type : Type == message.Type;
}