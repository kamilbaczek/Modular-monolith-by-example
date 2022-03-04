namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Approve;

using Application.Valuations.Commands.ApproveProposal;

internal sealed class RejectEndpoint : EndpointBaseAsync.WithRequest<ApproveProposalCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public RejectEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPatch]
    [Route($"{ValuationsRouting.Url}/proposals/reject")]
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
