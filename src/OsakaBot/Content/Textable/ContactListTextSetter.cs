namespace Osaka.Bot.Content.Textable;

public class ContactListTextSetter : TextSetterBase
{
    public int? ContactId { get; set; }
    public InnerContact? Contact
    {
        get; set;
    }

    public int? ReportId { get; set; }
    public Report? Report { get; set; }

    public ContactListTextSetter() => Type = TextSetterType.ContactList;
}

public class ContactListTextSetterApplier : ITextSetterApplier<ContactListTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}