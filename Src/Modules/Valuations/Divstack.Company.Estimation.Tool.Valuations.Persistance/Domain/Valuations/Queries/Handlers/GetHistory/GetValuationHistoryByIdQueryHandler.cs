﻿namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetHistory;

using Application.Valuations.Queries.GetHistoryById;
using Application.Valuations.Queries.GetHistoryById.Dtos;
using Marten;
using MediatR;

internal sealed class
    GetValuationHistoryByIdQueryHandler : IRequestHandler<GetValuationHistoryByIdQuery, ValuationHistoryVm>
{
    private readonly IDocumentStore _documentStore;
    public GetValuationHistoryByIdQueryHandler(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public async Task<ValuationHistoryVm> Handle(GetValuationHistoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var historyDto = await _documentStore
            .LightweightSession()
            .Query<ValuationHistoryDto>()
            .Where(valuation => valuation.Id == request.ValuationId)
            .FirstAsync(cancellationToken);

        var historicalEntries = historyDto
            .History
            .OrderBy(historicalEntry => historicalEntry.ChangeDate)
            .ToList();

        var vm = new ValuationHistoryVm(historicalEntries);

        return vm;
    }
}
