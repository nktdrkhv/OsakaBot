namespace Osaka.Bot.InputSystem;

public interface IAutoInputService
{
    public ValueTask<ICollection<AutoInputPair>> DecomposeAsync(object input, AutoInputType type);
}