using Microsoft.EntityFrameworkCore;

namespace Osaka.Bot.Content.Textable;

public class EnteredDataTextSetter : TextSetterBase
{
    public string VariableName { get; set; } = null!;
    public Variable Variable { get; set; } = null!;

    protected EnteredDataTextSetter() { }

    public EnteredDataTextSetter(string variableName)
    {
        Type = TextSetterType.EnteredData;
        VariableName = variableName;
    }

    public EnteredDataTextSetter(Variable variable)
    {
        Type = TextSetterType.EnteredData;
        Variable = variable;
    }
}

public class EnteredDataTextSetterApplier : ITextSetterApplier<EnteredDataTextSetter>
{
    private readonly IRepository _repository;

    public EnteredDataTextSetterApplier(IRepository repository) => _repository = repository;

    public async ValueTask<string> Apply(TextSetterBase setter)
    {
        var concrete = (EnteredDataTextSetter)setter;
        var enteredData = await _repository.GetAsync<EnteredData>(
            ed => ed.VariableName == concrete.VariableName && ed.AuthorId == concrete.User.InnerUserId,
            ed => ed.AsNoTracking().Include(ed => ed.InnerMessage).ThenInclude(ed => ed!.Text));
        return enteredData.BasicText ?? enteredData.InnerMessage?.Text?.OriginalText ?? string.Empty;
    }
}