namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationPriorityForcedDomainEvent : DomainEventBase
{
    public ValuationPriorityForcedDomainEvent(ValuationId valuationId)
    {
        ValuationId = valuationId;
    }
    public ValuationId ValuationId { get; }
}
