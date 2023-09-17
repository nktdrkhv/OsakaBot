namespace Osaka.Bot.Content.Textable;

public class EnteredDataTextSetter : TextSetterBase
{
    public string VariableName { get; set; } = null!;
    public Variable Variable { get; set; } = null!;

    public EnteredDataTextSetter() => Type = TextSetterType.EnteredData;
}

public class EnteredDataTextSetterApplier : ITextSetterApplier<EnteredDataTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}