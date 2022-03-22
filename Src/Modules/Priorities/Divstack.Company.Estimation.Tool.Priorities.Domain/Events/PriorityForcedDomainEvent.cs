namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityForcedDomainEvent : DomainEventBase
{
    public PriorityId PriorityId { get; }
    public PriorityLevel Level { get; }

    public PriorityForcedDomainEvent(PriorityId priorityId, PriorityLevel level)
    {
        Level = level;
        PriorityId = priorityId;
    }
}
