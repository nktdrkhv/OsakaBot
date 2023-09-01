namespace Osaka.Bot.InputSystem;

public class ActualDialogue
{
    public int CompletedDialogueId { get; set; }
    public Dialogue Source { get; set; } = null!;
    public DateTime Started { get; set; } = DateTime.Now.ToUniversalTime();
    public DateTime? Finished { get; set; }
}