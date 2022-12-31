namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

public sealed record ValuationHistoricalEntryDto(Guid Id, string Status, DateTime ChangeDate);
