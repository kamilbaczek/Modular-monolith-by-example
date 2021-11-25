namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

public record ValuationHistoricalEntryDto(Guid HistoricalEntryId, string Status, DateTime ChangeDate);
