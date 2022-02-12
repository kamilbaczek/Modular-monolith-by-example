namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationPrioritiesLevelIncresedDomainEvent : DomainEventBase
{
    public ValuationPrioritiesLevelIncresedDomainEvent(ValuationId valuationId)
    {
        ValuationId = valuationId;
    }
    public ValuationId ValuationId { get; }
}
