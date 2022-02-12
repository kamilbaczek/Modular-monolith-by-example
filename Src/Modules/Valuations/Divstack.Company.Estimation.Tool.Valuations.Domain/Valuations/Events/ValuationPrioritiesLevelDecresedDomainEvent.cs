namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationPrioritiesLevelDecresedDomainEvent : DomainEventBase
{
    public ValuationPrioritiesLevelDecresedDomainEvent(ValuationId valuationId)
    {
        ValuationId = valuationId;
    }
    public ValuationId ValuationId { get; }
}
