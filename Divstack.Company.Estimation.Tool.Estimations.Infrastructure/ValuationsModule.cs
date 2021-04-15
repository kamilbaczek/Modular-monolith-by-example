using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure
{
    internal sealed class ValuationsModule : IValuationsModule
    {
        private readonly IMediator _mediator;

        public ValuationsModule(IMediator mediator)
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
}
