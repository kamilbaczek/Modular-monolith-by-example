using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations
{
    public sealed class Service : Entity
    {
        private Service()
        {
        }

        private Service(ServiceId id, Enquiry enquiry)
        {
            Id = id;
            Enquiry = enquiry;
        }

        internal static Service Create(ServiceId id, Enquiry enquiry)
        {
            return new (id, enquiry);
        }

        private ServiceId Id { get; }
        private Enquiry Enquiry { get; }
    }
}
