using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public interface IValuationsRepository
    {
        Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default);
        Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
