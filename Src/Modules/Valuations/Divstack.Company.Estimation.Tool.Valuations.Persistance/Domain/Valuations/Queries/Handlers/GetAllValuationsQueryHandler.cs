namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.Get.Dtos;
using Application.Valuations.Queries.GetAll;
using Marten;
using MediatR;
using Tool.Valuations.Domain.Valuations;

internal sealed class GetAllValuationsQueryHandler : IRequestHandler<GetAllValuationsQuery, ValuationListVm>
{
    private readonly IDocumentStore _documentStore;
    public GetAllValuationsQueryHandler(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public Task<ValuationListVm> Handle(GetAllValuationsQuery request, CancellationToken cancellationToken)
    {
        // var valuations = await _documentStore.LightweightSession().LoadAsync<IReadOnlyList<ValuationListItemDto>>();

        return Task.FromResult(new ValuationListVm(new List<ValuationListItemDto>()));
    }
}
