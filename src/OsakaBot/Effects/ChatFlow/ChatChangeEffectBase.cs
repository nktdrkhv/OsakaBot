namespace Osaka.Bot.Effects.ChatFlow;

public abstract class ChatChangeEffectBase : EffectBase
{
    public Target Target { get; set; } = null!;
    public Source Source { get; set; } = null!;

    public abstract override void SetArguments(string[] args);
}