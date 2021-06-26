using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos
{
    public sealed class ValuationsServiceItemDto
    {
        public ValuationsServiceItemDto(Guid serviceId)
        {
            ServiceId = serviceId;
        }

        public Guid ServiceId { get; }
    }
}