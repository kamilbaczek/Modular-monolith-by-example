namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityForcedDomainEvent : DomainEventBase
{
    public PriorityForcedDomainEvent(PriorityId priorityId, PriorityLevel level)
    {
        Level = level;
        PriorityId = priorityId;
    }
    public PriorityId PriorityId { get; }
    public PriorityLevel Level { get; }
}
