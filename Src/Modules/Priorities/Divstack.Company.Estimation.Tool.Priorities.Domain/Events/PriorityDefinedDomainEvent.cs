namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Deadlines;
using Shared.DDD.BuildingBlocks;

public sealed class PriorityDefinedDomainEvent : DomainEventBase
{
    public PriorityDefinedDomainEvent(ValuationId valuationId, PriorityId priorityId, Deadline deadline)
    {
        ValuationId = valuationId;
        PriorityId = priorityId;
        Deadline = deadline;
    }

    public ValuationId ValuationId { get; }
    public PriorityId PriorityId { get; }
    public Deadline Deadline { get; }
}
