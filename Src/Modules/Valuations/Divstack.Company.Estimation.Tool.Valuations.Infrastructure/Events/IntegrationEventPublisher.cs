using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events.Mapper;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events
{
    internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
    {
        private readonly IEventMapper _eventMapper;
        private readonly IMediator _mediator;

        public IntegrationEventPublisher(IMediator mediator, IEventMapper eventMapper)
        {
            _mediator = mediator;
            _eventMapper = eventMapper;
        }

        public void Publish(IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            var integrationEvents = _eventMapper.Map(domainEvents);
            foreach (var integrationEvent in integrationEvents) _mediator.Publish(integrationEvent);
        }
    }
}