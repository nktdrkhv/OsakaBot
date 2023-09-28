namespace Osaka.Bot.Effects.ChatFlow;

public abstract class ChatChangingEffectBase : EffectBase
{
    public int? TargetId { get; protected set; }
    public Target? Target { get; protected set; }

    public int? SourceId { get; protected set; }
    public Source? Source { get; protected set; }

    protected ChatChangingEffectBase(EffectType type, byte order = 0) : base(type, order) { }
    protected ChatChangingEffectBase() { }

    public abstract override void SetArguments(object[] args);
}