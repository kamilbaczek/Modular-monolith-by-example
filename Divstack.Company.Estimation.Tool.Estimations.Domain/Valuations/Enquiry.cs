using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public sealed class Enquiry : ValueObject
    {
        private Enquiry()
        {
        }

        private Enquiry(
            Valuation valuation,
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            Valuation = valuation ?? throw new ArgumentNullException(nameof(valuation));
            if (!productsIds.Any())
                throw new InvalidOperationException("Cannot request valuation without products");
            Products = productsIds.Select(productsId => Product.Create(productsId, this)).ToList().AsReadOnly();
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        internal static Enquiry Create(
            Valuation valuation,
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            return new (valuation, productsIds, client);
        }

        internal Email ClientEmail => Client.Email;
        private Valuation Valuation  { get; }
        private IReadOnlyList<Product> Products { get; }
        private Client Client { get; }
    }
}
