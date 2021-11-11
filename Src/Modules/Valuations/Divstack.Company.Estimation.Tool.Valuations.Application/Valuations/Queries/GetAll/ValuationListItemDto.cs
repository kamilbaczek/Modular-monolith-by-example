using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

public record ValuationListItemDto(
    Guid ValuationId,
    Guid InquiryId,
    string Status,
    DateTime RequestedDate,
    Guid? CompletedBy);
