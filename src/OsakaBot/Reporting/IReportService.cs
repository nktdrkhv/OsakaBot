namespace Osaka.Bot.Reporting;

public interface IReportService
{
    ValueTask BroadcastReport(Report report);

}