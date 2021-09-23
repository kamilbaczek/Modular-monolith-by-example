using System;
using Ardalis.GuardClauses;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History
{
    public sealed class HistoricalEntry : Entity
    {
        private HistoricalEntry()
        {
        }

        private HistoricalEntry(Valuation valuation, ValuationStatus status)
        {
            Status = Guard.Against.Null(status, nameof(Status));
            Valuation = Guard.Against.Null(valuation, nameof(Valuation));
            ChangeDate = SystemTime.Now();
            Id = new HistoricalEntryId(Guid.NewGuid());
        }

        private Valuation Valuation { get; }
        internal ValuationStatus Status { get; }
        internal DateTime ChangeDate { get; }
        private HistoricalEntryId Id { get; }

        internal static HistoricalEntry Create(Valuation valuation, ValuationStatus status)
        {
            return new HistoricalEntry(valuation, status);
        }
    }
}