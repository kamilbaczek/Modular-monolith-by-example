namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish;

using Application.Common.IntegrationsEvents;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    // private readonly IBus _eventBusPublisher;
    // private readonly IEventMapper _eventMapper;
    // private readonly IPaymentsTopicConfiguration _paymentsTopicConfiguration;
    //
    // public IntegrationEventPublisher(IBus eventBusPublisher,
    //     IEventMapper eventMapper,
    //     IPaymentsTopicConfiguration paymentsTopicConfiguration)
    // {
    //     _eventBusPublisher = eventBusPublisher;
    //     _eventMapper = eventMapper;
    //     _paymentsTopicConfiguration = paymentsTopicConfiguration;
    // }

    public Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
