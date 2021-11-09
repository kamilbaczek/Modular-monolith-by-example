using System;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos
{
    public sealed class InquiriesServiceItemDto
    {
        public InquiriesServiceItemDto(Guid serviceId)
        {
            ServiceId = serviceId;
        }

        public Guid ServiceId { get; }
    }
}