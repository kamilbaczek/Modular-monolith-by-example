namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure;

using Application.Common.Contracts;
using MediatR;

internal sealed class ValuationsModule : IValuationsModule
{
    private readonly IMediator _mediator;

    public ValuationsModule(IMediator mediator) => _mediator = mediator;

    public async Task ExecuteCommandAsync(ICommand command) => await _mediator.Send(command);

    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command) => await _mediator.Send(command);

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query) => await _mediator.Send(query);
}
