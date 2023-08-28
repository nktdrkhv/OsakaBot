namespace Osaka.Bot.Content;

public class EnteredDataTextSetter : TextSetterBase
{

}

public class EnteredDataTextSetterApplier : ITextSetterApplier<EnteredDataTextSetter>
{
    public Task<string> Apply(EnteredDataTextSetter effect)
    {
        throw new NotImplementedException();
    }
}