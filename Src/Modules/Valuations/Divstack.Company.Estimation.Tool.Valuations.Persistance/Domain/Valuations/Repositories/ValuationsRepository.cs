namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Tool.Valuations.Domain.Valuations;
using Tool.Valuations.Domain.Valuations.States;

[UsedImplicitly]
public sealed class ValuationsRepository: IValuationsRepository
{
    private readonly IDocumentStore _documentStore;

    public ValuationsRepository(IDocumentStore documentStore) => _documentStore = documentStore;

    public async Task<TValuation> GetAsync<TValuation>(ValuationId valuationId, CancellationToken cancellationToken = default) where TValuation : class, IValuationState
    {
        var id = valuationId.Value;
        await using var documentSession = _documentStore.LightweightSession();
        var valuation = await documentSession.Events.AggregateStreamAsync<TValuation>(id, token: cancellationToken);

        return valuation!;
    }

    public async Task AddAsync(ValuationRequested valuation, CancellationToken cancellationToken = default)
    {
        var events = valuation.DomainEvents;

        await using var documentSession = _documentStore.OpenSession();
        documentSession.Events.StartStream<ValuationRequested>(
            valuation.Id,
            events
        );
        await documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync<TValuation>(TValuation valuation, CancellationToken cancellationToken = default) where TValuation : class, IValuationState
    {
        await using var documentSession = _documentStore.LightweightSession();
        documentSession.Events.Append(
            valuation.ValuationId.Value,
            valuation.DomainEvents
        );

        await documentSession.SaveChangesAsync(cancellationToken);
    }
}
