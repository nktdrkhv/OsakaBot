namespace Osaka.Bot.Effects.InputSystem;

public abstract class DialogueEffectBase : EffectBase
{
    public int? DialogueId { get; set; }
    public Dialogue? Dialogue { get; set; }

    protected DialogueEffectBase(Dialogue? dialogue, EffectType type, byte order = 0) : base(type, order)
        => Dialogue = dialogue;

    protected DialogueEffectBase() { }

    public abstract override void SetArguments(string[] args);
}