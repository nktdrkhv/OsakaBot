namespace Osaka.Bot.Content;

public class UserInput
{
    public int UserInputId { get; set; }
    public ICollection<ValidationBase>? Validators { get; set; }
    public Trigger OnValidInput { get; set; } = null!;
    public Trigger? OnInvalidInput { get; set; }
}