using MixERP.Net.VCards;
using Telegram.Bot.Types;

namespace Osaka.Bot.UserSpecific;

public class InnerContact
{
    public int InnerContactId { get; set; }
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Title { get; set; }
    public string? Organization { get; set; }

    public InnerContact() { }
    public InnerContact(Contact contact)
    {
        FullName = contact.LastName is null ? contact.FirstName : $"{contact.FirstName} {contact.LastName}";
        PhoneNumber = contact.PhoneNumber;
        if (contact.Vcard is string plainVCard)
        {
            var vCard = Deserializer.GetVCard(plainVCard);
            Email = vCard.Emails.OrderBy(e => e.Preference).FirstOrDefault()?.EmailAddress;
            Title = string.IsNullOrWhiteSpace(vCard.Title) ? null : vCard.Title;
            Organization = string.IsNullOrWhiteSpace(vCard.Organization) ? null : vCard.Organization;
        }
    }
}