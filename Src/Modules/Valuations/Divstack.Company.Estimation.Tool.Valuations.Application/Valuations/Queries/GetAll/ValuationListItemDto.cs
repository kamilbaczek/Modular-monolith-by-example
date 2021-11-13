namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

using System;

public record ValuationListItemDto(
    Guid ValuationId,
    Guid InquiryId,
    string Status,
    DateTime RequestedDate,
    Guid? CompletedBy);
