﻿using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure
{
    internal sealed class InquiriesModule : IInquiriesModule
    {
        private readonly IMediator _mediator;

        public InquiriesModule(IMediator mediator)
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