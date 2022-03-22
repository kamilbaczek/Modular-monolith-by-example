namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityArchivedDomainEvent : DomainEventBase
{
    public PriorityId PriorityId { get; }
    public PriorityArchivedDomainEvent(PriorityId priorityId)
    {
        PriorityId = priorityId;
    }
}
