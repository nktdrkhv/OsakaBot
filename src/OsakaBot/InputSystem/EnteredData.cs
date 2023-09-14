namespace Osaka.Bot.InputSystem;

public class EnteredData
{
    public int EnteredDataId { get; set; }

    public string VariableName { get; set; } = null!;
    public Variable Variable { get; set; } = null!;

    public int? AuthorId { get; set; }
    public InnerUser Author { get; set; } = null!;

    public int? AttachedToId { get; set; }
    public ActualDialogue? AttachedTo { get; set; }

    public string? BasicText { get; set; }
    public int? InnerMessageId { get; set; }
    public InnerMessage? InnerMessage { get; set; }

    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}