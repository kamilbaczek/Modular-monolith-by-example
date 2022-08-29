namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Marten;
using Tool.Valuations.Domain.Valuations;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IDocumentSession _documentSession;

    public ValuationsRepository(IDocumentSession documentSession) => _documentSession = documentSession;

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        var id = valuationId.Value;
        var valuation = await _documentSession.Events.AggregateStreamAsync<Valuation>(id, token: cancellationToken);

        return valuation!;
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        var events = valuation.DomainEvents;
        _documentSession.Events.StartStream<Valuation>(
            valuation.Id,
            events
        );

        await _documentSession.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        _documentSession.Events.Append(
            valuation.ValuationId.Value,
            valuation.DomainEvents
        );

        await _documentSession.SaveChangesAsync(cancellationToken);
    }
}
