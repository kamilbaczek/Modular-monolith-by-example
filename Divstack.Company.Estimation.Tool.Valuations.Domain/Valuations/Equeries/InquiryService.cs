using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries
{
    public sealed class InquiryService : Entity
    {
        private InquiryService()
        {
        }

        private InquiryService(ServiceId serviceId, Enquiry enquiry)
        {
            Id = new InquiryServiceId(Guid.NewGuid());
            ServiceId = serviceId;
            Enquiry = enquiry;
        }

        internal static InquiryService Create(ServiceId serviceId, Enquiry enquiry)
        {
            return new (serviceId, enquiry);
        }

        private ServiceId ServiceId { get; }
        private InquiryServiceId Id { get; }
        private Enquiry Enquiry { get; }
    }
}
