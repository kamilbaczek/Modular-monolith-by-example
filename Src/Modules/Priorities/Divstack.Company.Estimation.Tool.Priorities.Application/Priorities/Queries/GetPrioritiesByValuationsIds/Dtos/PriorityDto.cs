namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

public record PriorityDto(Guid PriorityId, Guid ValuationId, Guid InquiryId, string Level, bool Archived);
