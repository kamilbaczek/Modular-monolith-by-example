namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public interface IPrioritiesRepository
{
    Task<Priority> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default);
    Task<Priority> GetAsync(PriorityId priorityId, CancellationToken cancellationToken = default);
    Task AddAsync(Priority priority, CancellationToken cancellationToken = default);
    Task CommitAsync(Priority updatedPriority, CancellationToken cancellationToken = default);
}
