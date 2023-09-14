using System.Globalization;
using MixERP.Net.VCards.Models;
using Telegram.Bot.Types;

namespace Osaka.Bot.InputSystem;

public class AutoInputService : IAutoInputService
{
    private readonly IRepository _repository;

    public AutoInputService(IRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<ICollection<AutoInputPair>> DecomposeAsync(object input, AutoInputType type)
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
        return Array.Empty<AutoInputPair>();
    }

    private async ValueTask<List<AutoInputPair>> ContactExtractAsync(InnerContact contact)
    {
        var result = new List<AutoInputPair>
        {
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("phone"), contact.PhoneNumber),
            new AutoInputPair(await _repository.GetByIdAsync<Variable>("name"), contact.FullName),
        };

        if (contact.Email != null)
            result.Add(new AutoInputPair(await _repository.GetByIdAsync<Variable>("email"), contact.Email));
        if (contact.Title != null)
            result.Add(new AutoInputPair(await _repository.GetByIdAsync<Variable>("title"), contact.Title));
        if (contact.Organization != null)
            result.Add(new AutoInputPair(await _repository.GetByIdAsync<Variable>("organization"), contact.Organization));

        return result;
    }

    private static readonly CultureInfo CultureInfoRu = new("ru-RU");

    private static ValueTask<AutoInputPair[]> DateTransformAsync(string input)
    {
        var date = DateOnly.Parse(input, CultureInfoRu);
        return ValueTask.FromResult(new AutoInputPair[] { new(null, date.ToLongDateString()) });
    }
}