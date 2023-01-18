namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;

using States;

public interface IValuationsRepository
{
    Task<TValuation> GetAsync<TValuation>(ValuationId valuationId, CancellationToken cancellationToken = default) where TValuation : class, IValuationState;
    Task AddAsync(ValuationRequested valuation, CancellationToken cancellationToken = default);
    Task CommitAsync<TValuation>(TValuation valuation, CancellationToken cancellationToken = default) where TValuation : class, IValuationState;
}
