namespace Osaka.Bot.Content;

public sealed class TextSetterDispatcher : ITextSetterDispatcher
{
    private readonly IServiceProvider _provider;

    public TextSetterDispatcher(IServiceProvider provider) => _provider = provider;

    public async Task<string> ResolveAsync<T>(T setter) where T : TextSetterBase
    {
        var resolver = _provider.GetRequiredService<ITextSetterApplier<T>>();
        return await resolver.Apply(setter);
    }
}