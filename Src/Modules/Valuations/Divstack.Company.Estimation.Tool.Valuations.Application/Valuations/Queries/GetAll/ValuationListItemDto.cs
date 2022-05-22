namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

public record struct ValuationListItemDto(
    Guid Id,
    Guid InquiryId,
    string Status,
    DateTime RequestedDate,
    Guid? CompletedBy);
