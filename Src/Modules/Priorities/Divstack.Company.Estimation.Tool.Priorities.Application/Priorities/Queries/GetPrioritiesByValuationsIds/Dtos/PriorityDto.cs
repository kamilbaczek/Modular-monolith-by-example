namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

public record PriorityDto(Guid PriorityId, Guid ValuationId, Guid InquiryId, string Level, bool Archived);
