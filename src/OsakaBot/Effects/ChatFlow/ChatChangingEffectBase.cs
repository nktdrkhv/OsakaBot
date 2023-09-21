namespace Osaka.Bot.Effects.ChatFlow;

public abstract class ChatChangingEffectBase : EffectBase
{
    public Target? Target { get; set; }
    public Source? Source { get; set; }

    public abstract override void SetArguments(string[] args);
}