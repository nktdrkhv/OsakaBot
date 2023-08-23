namespace Osaka.Bot.Content;

public interface ITextSetterApplier<T> where T : TextSetterBase
{
    Task<string> Apply(T effect);
}