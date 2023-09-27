namespace Osaka.Bot.Content.Textable;

public class TicketsTextSetter : TextSetterBase
{
    public SentReportStatus TicketStatus { get; private set; }
    public byte Limit { get; private set; }

    public TicketsTextSetter(SentReportStatus status, byte limit = 0)
    {
        Type = TextSetterType.Tickets;
        (TicketStatus, Limit) = (status, limit);
    }

    protected TicketsTextSetter() { }
}

public class TicketsTextSetterApplier : ITextSetterApplier<TicketsTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase setter)
    {
        var concrete = (TicketsTextSetter)setter;
        throw new NotImplementedException();
    }
}