namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Marten;
using Tool.Valuations.Domain.Valuations;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IDocumentSession _documentSession;
    public ValuationsRepository()
    {
        const string connectionString =
            "PORT = 5432; HOST = localhost; TIMEOUT = 15; POOLING = True; DATABASE = 'postgres'; PASSWORD = 'Password12!'; USER ID = 'postgres'";

        var store = DocumentStore.For(connectionString);
        _documentSession = store.LightweightSession();
    }

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        var id = valuationId.Value.ToString();
        var valuation = await _documentSession.Events.AggregateStreamAsync<Valuation>(id, token: cancellationToken);

        return valuation;
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        // _documentSession.CorrelationId = traceMetadata?.CorrelationId?.Value;
        // _documentSession.CausationId = traceMetadata?.CausationId?.Value;
        var events = valuation.DomainEvents;

        _documentSession.Events.StartStream<Valuation>(
            valuation.Id.Value,
            events
        );

        await _documentSession.SaveChangesAsync(cancellationToken);
    }
    public async Task CommitAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        _documentSession.Events.Append(
            valuation.Id.Value,
            valuation.DomainEvents
        );

        await _documentSession.SaveChangesAsync(cancellationToken);
    }
}
