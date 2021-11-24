namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;

using System;

public record ValuationInformationDto(Guid ValuationId,
    string Status,
    Guid InquiryId,
    Guid? CompletedBy,
    DateTime RequestedDate);
