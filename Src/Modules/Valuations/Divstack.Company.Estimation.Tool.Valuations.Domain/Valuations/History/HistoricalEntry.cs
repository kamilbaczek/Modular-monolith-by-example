using System;
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
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Valuation = valuation ?? throw new ArgumentNullException(nameof(valuation));
            ChangeDate = SystemTime.Now();
            Id = new HistoricalEntryId(Guid.NewGuid());
        }

        private Valuation Valuation { get; }
        internal ValuationStatus Status { get; }
        internal DateTime ChangeDate { get; }
        private HistoricalEntryId Id { get; }

        internal static HistoricalEntry Create(Valuation valuation, ValuationStatus status)
        {
            return new(valuation, status);
        }
    }
}