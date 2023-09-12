namespace Osaka.Bot.InputSystem;

public interface IAutoInputService
{
    public ValueTask<List<AutoInputPair>> DecomposeAsync(object input, AutoInputType type);
}