namespace Osaka.Bot.Abstract;

public interface IMarkupBuilder<T>
{
    ValueTask<T> BuildMarkupAsync(CompositeArgument args);
}