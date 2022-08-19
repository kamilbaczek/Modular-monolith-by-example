namespace Divstack.Company.Estimation.Tool.Users.Infrastructure;

using System.Threading.Tasks;
using Application.Contracts;
using MediatR;

internal sealed class UserModule : IUserModule
{
    private readonly IMediator _mediator;

    public UserModule(IMediator mediator)
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
