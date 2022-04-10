namespace Divstack.Company.Estimation.Tool.Valuations.Api.Endpoints.Commands.Complete;

using Application.Valuations.Commands.Complete;
using Suggest;

[Route($"{ValuationsRouting.Url}/proposals/complete")]
internal sealed class CompleteEndpoint : EndpointBaseAsync.WithRequest<CompleteCommand>.WithoutResult
{
    private readonly IValuationsModule _valuationsModule;
    public CompleteEndpoint(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpPatch]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(
        Summary = nameof(SuggestEndpoint),
        Tags = new[]
        {
            nameof(ValuationModule)
        })
    ]
    public override async Task HandleAsync(CompleteCommand command, CancellationToken cancellationToken = new())
    {
        await _valuationsModule.ExecuteCommandAsync(command);
    }
}
