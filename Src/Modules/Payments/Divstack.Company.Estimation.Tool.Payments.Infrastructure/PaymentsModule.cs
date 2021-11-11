using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Payments.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure
{
    internal sealed class PaymentsModule : IPaymentsModule
    {
        private readonly IMediator _mediator;

        public PaymentsModule(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await _mediator.Send(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _mediator.Send(query);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await _mediator.Send(command);
        }
    }
}