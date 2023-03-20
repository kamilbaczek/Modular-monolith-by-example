namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.Domain.Priorities.Repositories;

using DataAccess;
using MongoDB.Driver;
using Tool.Priorities.Domain;

internal sealed class PrioritiesRepository : IPrioritiesRepository
{
    private readonly IPrioritiesContext _prioritiesContext;

    public PrioritiesRepository(IPrioritiesContext prioritiesContext) => _prioritiesContext = prioritiesContext;

    public async Task<Priority> GetAsync(PriorityId priorityId, CancellationToken cancellationToken = default)
    {
        return await _prioritiesContext.Priorities
            .Find(priority => priority.Id == priorityId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<Priority> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        return await _prioritiesContext.Priorities
            .Find(priority => priority.ValuationId == valuationId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Priority priority, CancellationToken cancellationToken = default) =>
        await _prioritiesContext.Priorities.InsertOneAsync(priority, cancellationToken: cancellationToken);

    public async Task CommitAsync(Priority updatedPriority, CancellationToken cancellationToken = default) =>
        await _prioritiesContext.Priorities.ReplaceOneAsync(priority => priority.Id == updatedPriority.Id,
            updatedPriority, cancellationToken: cancellationToken);
}
