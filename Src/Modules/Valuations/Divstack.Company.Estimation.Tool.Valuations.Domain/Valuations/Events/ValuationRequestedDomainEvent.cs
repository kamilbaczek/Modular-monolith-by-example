using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events
{
    public sealed class ValuationRequestedDomainEvent : DomainEventBase
    {
        public ValuationRequestedDomainEvent(ValuationId valuationId, Email clientEmail)
        {
            ValuationId = valuationId;
            ClientEmail = clientEmail;
        }

        public ValuationId ValuationId { get; }
        public Email ClientEmail { get; }
    }
}
