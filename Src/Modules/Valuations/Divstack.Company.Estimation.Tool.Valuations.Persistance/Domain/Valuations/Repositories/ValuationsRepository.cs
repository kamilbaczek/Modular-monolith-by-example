namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using MongoDB.Driver;
using Tool.Valuations.Domain.Valuations;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IValuationsContext _valuationsContext;

    public ValuationsRepository(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        return await _valuationsContext.Valuations
            .Find(valuation => valuation.Id.Value == valuationId.Value)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        await _valuationsContext.Valuations.InsertOneAsync(valuation, cancellationToken: cancellationToken);
    }

    public async Task CommitAsync(Valuation updatedValuation, CancellationToken cancellationToken = default)
    {
        await _valuationsContext.Valuations.ReplaceOneAsync(valuation => valuation.Id == updatedValuation.Id,
            updatedValuation, cancellationToken: cancellationToken);
    }
}
