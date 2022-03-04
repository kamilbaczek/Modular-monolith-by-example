namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Cancel;

using Application.Valuations.Commands.CancelProposal;

internal sealed class CancelEndpoint : EndpointBaseAsync.WithRequest<CancelProposalCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public CancelEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPatch]
    [Route($"{ValuationsRouting.Url}/proposals/cancel")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(CancelEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task HandleAsync([FromBody] CancelProposalCommand command, CancellationToken cancellationToken = new())
    {
        await _valuationsModule.ExecuteCommandAsync(command);
    }
}
