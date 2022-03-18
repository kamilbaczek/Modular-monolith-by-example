namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Events;

using Shared.DDD.BuildingBlocks;

public sealed class PriorityIncreasedDomainEvent : DomainEventBase
{
    public PriorityId PriorityId { get; }
    public PriorityLevel Level { get; }

    public PriorityIncreasedDomainEvent(PriorityId priorityId, PriorityLevel level)
    {
        PriorityId = priorityId;
        Level = level;
    }
}
