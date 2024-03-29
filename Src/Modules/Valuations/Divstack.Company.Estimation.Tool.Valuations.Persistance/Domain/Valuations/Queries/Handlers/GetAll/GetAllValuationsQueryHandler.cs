﻿namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.GetAll;

using Application.Valuations.Queries.GetAll;
using MediatR;

internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
{
    private readonly IDocumentStore _documentStore;

    public GetAllValuationsQueryHandler(IDocumentStore documentStore) => _documentStore = documentStore;

    public async Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
    {
        await using var documentSession = _documentStore.LightweightSession();
        var valuations = await documentSession
            .Query<ValuationListItemDto>()
            .OrderByDescending(valuationListItemDto => valuationListItemDto.RequestedDate)
            .ToListAsync(cancellationToken);
        var vm = new ValuationListVm(valuations);

        return vm;
    }
}
