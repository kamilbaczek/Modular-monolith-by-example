namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Queries.GetHistory;

using Application.Valuations.Queries.GetHistoryById;
using Application.Valuations.Queries.GetHistoryById.Dtos;

internal sealed class GetHistoryEndpoint : EndpointBaseAsync.WithRequest<Guid>
                                                            .WithResult<ActionResult<ValuationHistoryVm>>
{
    private readonly IValuationsModule _valuationsModule;
    public GetHistoryEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpGet("{id}")]
    [Route($"{ValuationsRouting.Url}/history")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(GetHistoryEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task<ActionResult<ValuationHistoryVm>> HandleAsync([FromQuery] Guid id, CancellationToken cancellationToken = new())
    {
        var query = new GetValuationHistoryByIdQuery(id);
        var historyVm = await _valuationsModule.ExecuteQueryAsync(query);

        return Ok(historyVm);
    }
}
