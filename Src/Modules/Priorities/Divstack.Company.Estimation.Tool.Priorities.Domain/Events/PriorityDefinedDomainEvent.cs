namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityDefinedDomainEvent : DomainEventBase
{
    public PriorityDefinedDomainEvent(ValuationId valuationId, PriorityId priorityId)
    {
        ValuationId = valuationId;
        PriorityId = priorityId;
    }

    public ValuationId ValuationId { get; }
    public PriorityId PriorityId { get; }

}
