namespace Osaka.Bot.Content;

public class UserInput
{
    public int UserInputId { get; set; }

    public bool HandleInvalidInput { get; set; } = false;
    public ICollection<ValidatorBase>? Validators { get; set; }
    // public FormattingType FormattingType {get;set;} // eg. ForrmattingType.Phone => +79999999999 -> +7 (999) 999-99-99

    public int OnValidInputId { get; set; }
    public Trigger OnValidInput { get; set; } = null!;

    public int? OnInvalidInputId { get; set; }
    public Trigger? OnInvalidInput { get; set; }
}