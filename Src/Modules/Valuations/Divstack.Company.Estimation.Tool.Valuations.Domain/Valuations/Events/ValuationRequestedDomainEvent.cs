using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events
{
    public sealed class ValuationRequestedDomainEvent : DomainEventBase
    {
        public ValuationRequestedDomainEvent(ValuationId valuationId, IReadOnlyList<ServiceId> serviceIds, Email clientEmail)
        {
            ValuationId = valuationId;
            ServiceIds = serviceIds;
            ClientEmail = clientEmail;
        }

        public ValuationId ValuationId { get; }
        public IReadOnlyList<ServiceId> ServiceIds { get; }
        public Email ClientEmail { get; }
    }
}
