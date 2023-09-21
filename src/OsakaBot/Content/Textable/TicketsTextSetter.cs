namespace Osaka.Bot.Content.Textable;

public class TicketsTextSetter : TextSetterBase
{
    public SentReportStatus TicketStatus { get; private set; }
    public byte Limit { get; private set; }
    protected TicketsTextSetter() => Type = TextSetterType.Tickets;
    public TicketsTextSetter(SentReportStatus status, byte limit = 0) : this() => (TicketStatus, Limit) = (status, limit);
}

public class TicketsSetterApplier : ITextSetterApplier<TicketsTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}