using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.InputSystem;

[Table("ActualDialogue")]
public class ActualDialogue
{
    public int ActualDialogueId { get; set; }

    public int UserId { get; set; }
    public InnerUser User { get; set; } = null!;

    public int SourceId { get; set; }
    public Dialogue Source { get; set; } = null!;

    public DateTime Started { get; set; } = DateTime.Now.ToUniversalTime();
    public DateTime? Finished { get; set; }
    public bool IsUnfinished { get; set; }

    public ICollection<EnteredData> EnteredData { get; set; } = null!;
}