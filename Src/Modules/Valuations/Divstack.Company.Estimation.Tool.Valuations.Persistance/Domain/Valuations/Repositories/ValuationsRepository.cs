namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Marten;
using Tool.Valuations.Domain.Valuations;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IDocumentStore _documentStore;

    public ValuationsRepository(IDocumentStore documentStore) => _documentStore = documentStore;

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        var id = valuationId.Value;
        await using var documentSession = _documentStore.LightweightSession();
        var valuation = await documentSession.Events.AggregateStreamAsync<Valuation>(id, token: cancellationToken);

        return valuation!;
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        var events = valuation.DomainEvents;

        await using var documentSession = _documentStore.LightweightSession();
        documentSession.Events.StartStream<Valuation>(
            valuation.Id,
            events
        );

        await documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        await using var documentSession = _documentStore.LightweightSession();
        documentSession.Events.Append(
            valuation.ValuationId.Value,
            valuation.DomainEvents
        );

        await documentSession.SaveChangesAsync(cancellationToken);
    }
}
