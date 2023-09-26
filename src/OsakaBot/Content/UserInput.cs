using Telegram.Bot.Types;

namespace Osaka.Bot.Content;

public class UserInput
{
    public int UserInputId { get; private set; }

    public bool HandleInvalidInput { get; private set; }
    public ICollection<ValidatorBase>? Validators { get; private set; }

    public int OnValidInputId { get; private set; }
    public Trigger OnValidInput { get; private set; } = null!;

    public int? OnInvalidInputId { get; private set; }
    public Trigger? OnInvalidInput { get; private set; }

    public FormattingType Format { get; private set; } = FormattingType.None;

    public UserInput(Trigger onValidInput, FormattingType format = FormattingType.None)
        => (OnValidInput, Format) = (onValidInput, format);

    public UserInput(Trigger onValidInput, Trigger onInvalidInput, ICollection<ValidatorBase> validators, bool handleInvalidInput, FormattingType format = FormattingType.None)
    {
        OnValidInput = onValidInput;
        OnInvalidInput = onInvalidInput;
        Validators = validators;
        HandleInvalidInput = handleInvalidInput;
        Format = format;
    }

    private UserInput() { }
}