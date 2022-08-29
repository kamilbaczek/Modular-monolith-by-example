namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Queries.Get;

using Application.Valuations.Queries.Get;
using Application.Valuations.Queries.Get.Dtos;

[Route(ValuationsRouting.Url)]
internal sealed class GetEndpoint : EndpointBaseAsync.WithRequest<Guid>.WithResult<ActionResult<ValuationVm>>
{
    private readonly IValuationsModule _valuationsModule;
    public GetEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(GetEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task<ActionResult<ValuationVm>> HandleAsync(Guid id, CancellationToken cancellationToken = new())
    {
        var query = GetValuationQuery.Create(id);
        var result = await _valuationsModule.ExecuteQueryAsync(query);

        return result;
    }
}
