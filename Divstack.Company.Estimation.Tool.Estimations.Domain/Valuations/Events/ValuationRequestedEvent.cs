using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events
{
    public sealed class ValuationRequestedEvent : DomainEventBase
    {
        public ValuationRequestedEvent(IReadOnlyList<ProductId> productsIds, Email clientEmail)
        {
            ProductsIds = productsIds;
            ClientEmail = clientEmail;
        }

        public IReadOnlyList<ProductId> ProductsIds { get; }
        public Email ClientEmail { get; }
    }
}
