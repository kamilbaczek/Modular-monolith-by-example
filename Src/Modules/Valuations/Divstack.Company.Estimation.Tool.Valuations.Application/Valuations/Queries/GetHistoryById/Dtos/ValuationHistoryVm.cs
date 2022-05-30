namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

public record ValuationHistoryVm(IReadOnlyCollection<ValuationHistoricalEntryDto> ValuationHistoricalEntries)
{
    public Guid RecentHistoricalEntryId => ValuationHistoricalEntries.First().Id;
}
