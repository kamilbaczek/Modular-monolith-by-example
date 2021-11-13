namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;

public record ValuationHistoryVm(IReadOnlyCollection<ValuationHistoricalEntryDto> ValuationHistoricalEntries)
{
    public Guid RecentHistoricalEntryId => ValuationHistoricalEntries.First().HistoricalEntryId;
}
