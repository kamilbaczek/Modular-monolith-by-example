namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish;

using IntegrationsEvents.External;
using Mapper;
using NServiceBus;
using Shared.DDD.BuildingBlocks;

internal sealed class IntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly IEventMapper _eventMapper;
    private readonly IMessageSession _messageSession;

    public IntegrationEventPublisher(IMessageSession messageSession,
        IEventMapper eventMapper)
    {
        _messageSession = messageSession;
        _eventMapper = eventMapper;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        var integrationEvents = _eventMapper
            .Map(domainEvents)
            .ToList()
            .AsReadOnly();

        foreach (var @event in integrationEvents)
        {
            switch (@event)
            {
                case InquiryMadeEvent inquiryMadeEvent:
                    await _messageSession.SendLocal(inquiryMadeEvent);
                    break;
            }
        }
    }
}
