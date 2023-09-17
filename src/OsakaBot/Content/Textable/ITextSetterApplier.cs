namespace Osaka.Bot.Content.Textable;

public interface ITextSetterApplier
{
    ValueTask<string> Apply(TextSetterBase textSetter);
}

public interface ITextSetterApplier<T> : ITextSetterApplier
    where T : TextSetterBase
{ }