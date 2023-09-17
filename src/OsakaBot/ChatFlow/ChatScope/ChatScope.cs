using System.ComponentModel.DataAnnotations.Schema;

namespace Osaka.Bot.ChatFlow.ChatScope;

[Table("ChatScope")]
public class ChatScope
{
    public int ChatScopeId { get; set; }
    public string? Phrase { get; set; }

    public int InnerUserId { get; set; }
    public InnerUser InnerUser { get; set; } = null!;

    public ICollection<ShowedMessage> ShowedMessages { get; set; } = null!;
    public ICollection<ActiveKeyboardTrigger>? PlainTriggers { get; set; }
    public ICollection<ActiveKeyboardTrigger>? EncodedTriggers { get; set; }
    public ICollection<ValidatorBase>? Validators { get; set; }

    public int? ActiveInputId { get; set; }
    public int? OnValidInputId { get; set; }
    public int? OnInvalidInputId { get; set; }
    public int? OnClearScopeId { get; set; }

    public ShowedMessage? ActiveInput { get; set; }
    public Trigger? OnValidInput { get; set; }
    public Trigger? OnInvalidInput { get; set; }
    public Trigger? OnScopeClean { get; set; }

    public bool HasToRedirectInvalidInput { get; set; } = false;

    public void InsertActiveTriggers(KeyboardType sourceOfTriggers, ICollection<ActiveKeyboardTrigger> triggers)
    {
        var target = sourceOfTriggers switch
        {
            KeyboardType.Inline => EncodedTriggers,
            KeyboardType.InlineDayPicker => EncodedTriggers,
            KeyboardType.Reply => PlainTriggers,
            KeyboardType.Remove => PlainTriggers,
            _ => throw new ArgumentException("KeyboardType is unsupported")
        };

        // if (sourceOfTriggers == KeyboardType.Remove)
        //     target.Clear()

        // if (target == null)
        //     target =
    }
}