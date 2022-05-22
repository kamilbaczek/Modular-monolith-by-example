namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Handlers;

using Application.Valuations.Queries.Get;
using Application.Valuations.Queries.Get.Dtos;
using Marten;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tool.Valuations.Domain.Valuations;

internal sealed class GetValuationsQueryHandler : IRequestHandler<GetValuationQuery, ValuationVm>
{
    private readonly IDocumentStore _documentStore;
    const string connectionString =
        "PORT = 5432; HOST = localhost; TIMEOUT = 15; POOLING = True; DATABASE = 'postgres'; PASSWORD = 'Password12!'; USER ID = 'postgres'";

    public GetValuationsQueryHandler()
    {
        _documentStore = DocumentStore.For(connectionString);
    }

    public async Task<ValuationVm> Handle([FromQuery] GetValuationQuery request, CancellationToken cancellationToken)
    {
        var valuationInformationDtos = await _documentStore.LightweightSession().LoadAsync<ValuationInformationDto>(request.ValuationId, cancellationToken);

        return new ValuationVm(valuationInformationDtos);
    }
}
