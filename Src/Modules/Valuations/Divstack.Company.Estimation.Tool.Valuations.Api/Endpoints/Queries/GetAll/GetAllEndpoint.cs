namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Queries.GetAll;

using Application.Valuations.Queries.GetAll;

[ExcludeFromCodeCoverage]
[Route(ValuationsRouting.Url)]
internal sealed class GetAllEndpoint : EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<ValuationListVm>>
{
    private readonly IValuationsModule _valuationsModule;
    public GetAllEndpoint(IValuationsModule valuationsModule) => _valuationsModule = valuationsModule;

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(GetAllEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task<ActionResult<ValuationListVm>> HandleAsync(CancellationToken cancellationToken = new())
    {
        var query = GetAllValuationsQuery.Create();
        var valuationsListVm = await _valuationsModule.ExecuteQueryAsync(query);

        return Ok(valuationsListVm);
    }
}
