namespace Osaka.Bot.Content.Textable;

public interface ITextSetterDispatcher
{
    Task<string> ResolveAsync<T>(T setter) where T : TextSetterBase;
}

public sealed class TextSetterDispatcher : ITextSetterDispatcher
{
    private readonly IServiceProvider _provider;
    private static readonly Type Generic = typeof(ITextSetterApplier<>);

    public TextSetterDispatcher(IServiceProvider provider) => _provider = provider;

    public async Task<string> ResolveAsync<T>(T setter) where T : TextSetterBase
    {
        var argType = setter.GetType();
        var constructed = Generic.MakeGenericType(argType);
        var applier = (ITextSetterApplier)_provider.GetRequiredService(constructed);
        return await applier.Apply(setter);
    }
}