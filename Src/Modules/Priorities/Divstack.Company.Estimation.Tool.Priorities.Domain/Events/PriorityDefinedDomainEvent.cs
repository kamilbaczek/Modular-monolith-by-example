namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityDefinedDomainEvent : DomainEventBase
{
    public PriorityDefinedDomainEvent(ValuationId valuationId, PriorityId priorityId, DateTime deadlineDate)
    {
        ValuationId = valuationId;
        PriorityId = priorityId;
        DeadlineDate = deadlineDate;
    }

    public ValuationId ValuationId { get; }
    public PriorityId PriorityId { get; }
    public DateTime DeadlineDate { get; }
}
