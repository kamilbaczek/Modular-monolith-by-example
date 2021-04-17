using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events
{
    public sealed class ValuationRequestedEvent : DomainEventBase
    {
        public ValuationRequestedEvent(IReadOnlyList<ServiceId> productsIds, Email clientEmail)
        {
            ProductsIds = productsIds;
            ClientEmail = clientEmail;
        }

        public IReadOnlyList<ServiceId> ProductsIds { get; }
        public Email ClientEmail { get; }
    }
}
