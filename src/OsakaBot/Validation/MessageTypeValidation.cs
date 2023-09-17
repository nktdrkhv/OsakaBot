namespace Osaka.Bot.Validation;

public class MessageTypeValidator : ValidatorBase
{
    public InnerMessageType DesiredType { get; set; }

    public MessageTypeValidator() => Type = ValidatorType.MessageType;

    public MessageTypeValidator(InnerMessageType type) : base()
    {
        DesiredType = type;
    }

    public override bool Validate(InnerMessage message) => Invert ? DesiredType != message.Type : DesiredType == message.Type;

    public override bool Validate(string text) => DesiredType == InnerMessageType.Text;
}