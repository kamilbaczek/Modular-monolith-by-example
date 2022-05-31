namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityArchivedDomainEvent : DomainEventBase
{
    public PriorityArchivedDomainEvent(PriorityId priorityId)
    {
        PriorityId = priorityId;
    }
    public PriorityId PriorityId { get; }
}
