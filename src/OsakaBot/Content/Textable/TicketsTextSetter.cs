namespace Osaka.Bot.Content.Textable;

public class TicketsTextSetter : TextSetterBase
{
    public SentReportStatus TicketStatus { get; set; }
    public TicketsTextSetter() => Type = TextSetterType.Tickets;
}

public class TicketsSetterApplier : ITextSetterApplier<TicketsTextSetter>
{
    public ValueTask<string> Apply(TextSetterBase effect)
    {
        throw new NotImplementedException();
    }
}