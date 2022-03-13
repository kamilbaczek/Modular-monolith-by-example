namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Reject;

using Application.Valuations.Commands.ApproveProposal;

[Route($"{ValuationsRouting.Url}/proposals/reject")]
internal sealed class RejectEndpoint : EndpointBaseAsync.WithRequest<ApproveProposalCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public RejectEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPatch]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = nameof(RejectEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task HandleAsync([FromBody] ApproveProposalCommand command, CancellationToken cancellationToken = new())
    {
        await _valuationsModule.ExecuteCommandAsync(command);
    }
}
