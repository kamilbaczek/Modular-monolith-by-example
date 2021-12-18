namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using DataAccess;
using MongoDB.Driver;
using Tool.Valuations.Domain.Valuations;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IValuationsNotificationsContext _valuationsNotificationsContext;

    public ValuationsRepository(IValuationsNotificationsContext valuationsNotificationsContext)
    {
        _valuationsNotificationsContext = valuationsNotificationsContext;
    }

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        return await _valuationsNotificationsContext.Valuations
            .Find(valuation => valuation.Id.Value == valuationId.Value)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        await _valuationsNotificationsContext.Valuations.InsertOneAsync(valuation, cancellationToken: cancellationToken);
    }

    public async Task CommitAsync(Valuation updatedValuation, CancellationToken cancellationToken = default)
    {
        await _valuationsNotificationsContext.Valuations.ReplaceOneAsync(valuation => valuation.Id == updatedValuation.Id,
            updatedValuation, cancellationToken: cancellationToken);
    }
}
