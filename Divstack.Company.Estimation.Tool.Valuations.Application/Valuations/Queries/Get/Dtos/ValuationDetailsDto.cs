using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos
{
    public record ValuationDetailsDto(ValuationInformationDto Information,
        IReadOnlyList<ValuationsServiceItemDto> Services);
}