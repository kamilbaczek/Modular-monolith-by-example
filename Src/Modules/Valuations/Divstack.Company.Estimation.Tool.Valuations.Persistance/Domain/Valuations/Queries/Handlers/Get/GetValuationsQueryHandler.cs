namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers.Get;

using Application.Valuations.Queries.Get;
using Application.Valuations.Queries.Get.Dtos;
using MediatR;

internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
{
    private readonly IDocumentStore _documentStore;

    public GetValuationsQueryHandler(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public async Task<ValuationVm> Handle(GetValuationQuery request, CancellationToken cancellationToken)
    {
        await using var documentSession = _documentStore.LightweightSession();
        var valuationInformationDtos = await documentSession.LoadAsync<ValuationInformationDto>(request.ValuationId, cancellationToken);
        return new ValuationVm(valuationInformationDtos);
    }
}
