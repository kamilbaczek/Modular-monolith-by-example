namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure;

using Common.Contracts;
using MediatR;

internal sealed class PrioritiesModule : IPrioritiesModule
{
    private readonly IMediator _mediator;

    public PrioritiesModule(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await _mediator.Send(command);
    }

    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        return await _mediator.Send(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        return await _mediator.Send(query);
    }
}
