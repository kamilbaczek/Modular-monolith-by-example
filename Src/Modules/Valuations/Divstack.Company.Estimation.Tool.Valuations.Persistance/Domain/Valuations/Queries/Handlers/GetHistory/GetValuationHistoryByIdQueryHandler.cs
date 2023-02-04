namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetHistory;

using Application.Valuations.Queries.GetHistoryById;
using Application.Valuations.Queries.GetHistoryById.Dtos;
using MediatR;

internal sealed class
    GetValuationHistoryByIdQueryHandler : IRequestHandler<GetValuationHistoryByIdQuery, ValuationHistoryVm>
{
    private readonly IDocumentStore _documentStore;
    public GetValuationHistoryByIdQueryHandler(IDocumentStore documentStore) => _documentStore = documentStore;

    public async Task<ValuationHistoryVm> Handle(GetValuationHistoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        await using var documentSession = _documentStore.LightweightSession();
        var historyDto = await documentSession
            .Query<ValuationHistoryDto>()
            .Where(valuation => valuation.Id == request.ValuationId)
            .FirstAsync(cancellationToken);

        var historicalEntries = historyDto
            .History
            .OrderByDescending(historicalEntry => historicalEntry.ChangeDate)
            .ToList();

        var vm = new ValuationHistoryVm(historicalEntries);

        return vm;
    }
}
