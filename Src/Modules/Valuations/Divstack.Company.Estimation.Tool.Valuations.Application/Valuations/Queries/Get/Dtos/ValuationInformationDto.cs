using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;

public record ValuationInformationDto(Guid ValuationId,
    string Status,
    Guid InquiryId,
    Guid? CompletedBy,
    DateTime RequestedDate);
