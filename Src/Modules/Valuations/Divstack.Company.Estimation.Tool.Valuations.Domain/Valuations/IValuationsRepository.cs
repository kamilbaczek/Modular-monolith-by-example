namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using System.Threading;
using System.Threading.Tasks;

public interface IValuationsRepository
{
    Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default);
    Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default);
    Task CommitAsync(Valuation valuation, CancellationToken cancellationToken = default);
}
