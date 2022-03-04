namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Suggest;

using Application.Valuations.Commands.SuggestProposal;

internal sealed class SuggestEndpoint : EndpointBaseAsync.WithRequest<SuggestProposalCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public SuggestEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPost]
    [Route($"{ValuationsRouting.Url}/proposals")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(SuggestEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task HandleAsync([FromBody] SuggestProposalCommand command, CancellationToken cancellationToken = new())
    {
        await _valuationsModule.ExecuteCommandAsync(command);
    }
}
