namespace Osaka.Bot.Effects.InputSystem;

public abstract class DialogueEffectBase : EffectBase
{
    public int DialogueId { get; set; }
    public Dialogue Dialogue { get; set; } = null!;

    public abstract override void SetArguments(string[] args);
}