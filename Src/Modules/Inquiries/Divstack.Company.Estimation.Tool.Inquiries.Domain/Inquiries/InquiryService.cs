using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries
{
    public sealed class InquiryService : Entity
    {
        private InquiryService()
        {
        }

        private InquiryService(ServiceId serviceId, Inquiry inquiry)
        {
            Id = new InquiryServiceId(Guid.NewGuid());
            ServiceId = serviceId;
            Inquiry = inquiry;
        }

        private ServiceId ServiceId { get; }
        private InquiryServiceId Id { get; }
        private Inquiry Inquiry { get; }

        internal static InquiryService Create(ServiceId serviceId, Inquiry inquiry)
        {
            return new(serviceId, inquiry);
        }
    }
}
