namespace Osaka.Bot.Content;

public class UserInput
{
    public int UserInputId { get; set; }
    public ICollection<ValidatorBase>? Validators { get; set; }
    public Trigger OnValidInput { get; set; } = null!;
    public Trigger? OnInvalidInput { get; set; }
    public bool HandleInvalidInput { get; set; } = false;
}