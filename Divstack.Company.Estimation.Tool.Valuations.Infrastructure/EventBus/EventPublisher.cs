using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.EventBus
{
    internal sealed class EventPublisher : IEventPublisher
    {
        private readonly IMediator _mediator;

        public EventPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Publish(IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                _mediator.Publish(domainEvent);
            }
        }
    }
}
