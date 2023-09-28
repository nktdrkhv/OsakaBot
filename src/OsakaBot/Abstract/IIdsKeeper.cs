namespace Osaka.Bot.Abstract;

public interface IIdsKeeper
{
    DateTime CreatedAt { get; set; }
    int CauseMessageId { get; }
    int[]? CauseMessagesIds { get; }

    IEnumerable<int> ExtractIds(TimeSpan? noOlderThen = null) =>
        noOlderThen != null && (DateTime.UtcNow.Subtract(CreatedAt) < noOlderThen) || noOlderThen == null
            ? CauseMessagesIds ?? (new int[] { CauseMessageId })
            : Array.Empty<int>();
}