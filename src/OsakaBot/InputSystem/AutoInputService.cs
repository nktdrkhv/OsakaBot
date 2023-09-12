using System.Globalization;
using Telegram.Bot.Types;

namespace Osaka.Bot.InputSystem;

public class AutoInputService : IAutoInputService
{
    private readonly IRepository _repository;

    public AutoInputService(IRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<List<AutoInputPair>> DecomposeAsync(object input, AutoInputType type)
    {
        switch (type)
        {
            case AutoInputType.Contact:
                if (input is InnerMessage msg && msg.Contact is InnerContact contact)
                    return await ContactExtractAsync(contact);
                break;
            case AutoInputType.Date:
                if (input is string date)
                    return await DateTransformAsync(date);
                break;
        }
        return new();
    }

    private async ValueTask<List<AutoInputPair>> ContactExtractAsync(InnerContact contact)
    {

        var result = new List<AutoInputPair>
        {
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("phone"), contact.PhoneNumber),
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("name"), contact.FullName),
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("email"), contact.Email),
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("title"), contact.Title),
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("organization"), contact.Organization)
        };
        return result;
    }

    private static ValueTask<List<AutoInputPair>> DateTransformAsync(string input)
    {
        var cultureInfo = new CultureInfo("ru-RU");
        var date = DateOnly.Parse(input, cultureInfo);
        return ValueTask.FromResult(new List<AutoInputPair>() { new(null, date.ToLongDateString()) });
    }
}