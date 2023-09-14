namespace Osaka.Bot.Content.Textable;

public class EnteredDataTextSetter : TextSetterBase
{
    public EnteredDataTextSetter()
    {
        Type = TextSetterType.EnteredData;
    }
}

public class EnteredDataTextSetterApplier : ITextSetterApplier<EnteredDataTextSetter>
{
    public Task<string> Apply(EnteredDataTextSetter effect)
    {
        throw new NotImplementedException();
    }
}