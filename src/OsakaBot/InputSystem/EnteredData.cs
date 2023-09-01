namespace Osaka.Bot.InputSystem;

public class EnteredData
{
    public int EnteredDataId { get; set; }
    public Variable Variable { get; set; } = null!;
    public InnerMessage? Message { get; set; }
    public Text? JustText { get; set; }
    public ActualDialogue? AttachedTo { get; set; }
}