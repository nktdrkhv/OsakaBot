namespace Osaka.Bot.InputSystem;

public record ActiveIncludedPost
{
    public IncludedPost IncludedPost { get; set; } = null!;
    public Variable Variable { get; set; } = null!;
    public ActualDialogue ActualDialogue { get; set; } = null!;
}