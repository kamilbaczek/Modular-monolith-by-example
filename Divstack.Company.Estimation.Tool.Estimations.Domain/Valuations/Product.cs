using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public sealed class Product : Entity
    {
        private Product()
        {
        }

        private Product(ProductId id, Enquiry enquiry)
        {
            Id = id;
            Enquiry = enquiry;
        }

        internal static Product Create(ProductId id, Enquiry enquiry)
        {
            return new (id, enquiry);
        }

        private ProductId Id { get; }
        private Enquiry Enquiry { get; }
    }
}
