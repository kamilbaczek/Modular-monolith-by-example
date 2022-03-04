namespace Divstack.Company.Estimation.Tool.Priorities.Api.Priorities;

using Domain;
using Tool.Priorities.Common.Contracts;
using Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds;
using Tool.Priorities.Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal sealed class Get : EndpointBaseAsync
    .WithoutRequest
    .WithResult<ActionResult<PrioritiesListVm>>
{
    private readonly IPrioritiesModule _prioritiesModule;
    public Get(IPrioritiesModule prioritiesModule)
    {
        _prioritiesModule = prioritiesModule;
    }

    [Route(PrioritiesRouting.Url)]
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(Get),
        Tags = new[] { nameof(PrioritiesModule) })
    ]
    public override async Task<ActionResult<PrioritiesListVm>> HandleAsync(
        CancellationToken cancellationToken = new())
    {
        var query = new GetPrioritiesQuery();
        var result = await _prioritiesModule.ExecuteQueryAsync(query);

        return result;
    }
}
