namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Approve;

using Application.Valuations.Commands.ApproveProposal;

[Route($"{ValuationsRouting.Url}/proposals/approve")]
internal sealed class ApproveEndpoint : EndpointBaseAsync.WithRequest<ApproveProposalCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public ApproveEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPatch]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = nameof(ApproveEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task HandleAsync(ApproveProposalCommand command, CancellationToken cancellationToken = new())
    {
        await _valuationsModule.ExecuteCommandAsync(command);
    }
}
