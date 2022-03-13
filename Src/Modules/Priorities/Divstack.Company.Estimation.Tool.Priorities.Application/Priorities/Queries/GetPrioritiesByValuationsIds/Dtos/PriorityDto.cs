namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

public record PriorityDto(Guid ValuationId, Guid InquiryId, Guid PriorityId, string Level, bool Archived);
