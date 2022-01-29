namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;

public sealed class HistoricalEntry : Entity
{
    private HistoricalEntry(ValuationStatus status)
    {
        Status = Guard.Against.Null(status, nameof(Status));
        ChangeDate = SystemTime.Now();
        Id = HistoricalEntryId.Create();
    }

    internal ValuationStatus Status { get; private set; }
    internal DateTime ChangeDate { get; init; }
    private HistoricalEntryId Id { get; init; }

    internal static HistoricalEntry Create(ValuationStatus status)
    {
        return new HistoricalEntry(status);
    }
}
