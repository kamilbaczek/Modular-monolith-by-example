namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

public interface IPrioritiesRepository
{
    Task<Priority> GetAsync(PriorityId priorityId, CancellationToken cancellationToken = default);
    Task AddAsync(Priority valuation, CancellationToken cancellationToken = default);
    Task CommitAsync(Priority valuation, CancellationToken cancellationToken = default);
}
