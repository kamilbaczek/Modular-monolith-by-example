namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;

using System;
using Ardalis.GuardClauses;
using Shared.DDD.BuildingBlocks;

public sealed class HistoricalEntry : Entity
{
    private HistoricalEntry(ValuationStatus status)
    {
        Status = Guard.Against.Null(status, nameof(Status));
        ChangeDate = SystemTime.Now();
        Id = new HistoricalEntryId(Guid.NewGuid());
    }

    internal ValuationStatus Status { get; private set; }
    internal DateTime ChangeDate { get; }
    private HistoricalEntryId Id { get; }

    internal static HistoricalEntry Create(ValuationStatus status)
    {
        return new HistoricalEntry(status);
    }
}
