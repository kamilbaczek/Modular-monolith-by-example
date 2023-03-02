namespace Divstack.Company.Estimation.Tool.Priorities.Api.Priorities;

using Application.Common.Contracts;
using Application.Priorities.Queries.GetPrioritiesByValuationsIds;
using Application.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal sealed class Get : EndpointBaseAsync.WithoutRequest.WithResult<ActionResult<PrioritiesListVm>>
{
    private readonly IPrioritiesModule _prioritiesModule;
    
    public Get(IPrioritiesModule prioritiesModule) =>
        _prioritiesModule = prioritiesModule;

    [Route(PrioritiesRouting.Url)]
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(Get),
        Tags = new[]
        {
            nameof(PrioritiesModule)
        })
    ]
    public override async Task<ActionResult<PrioritiesListVm>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var query = GetPrioritiesQuery.Create();
        var result = await _prioritiesModule.ExecuteQueryAsync(query);

        return result;
    }
}
