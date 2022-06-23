namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events.Publish.Mapper;

using Domain.Inquiries.Events;
using IntegrationsEvents.External;
using Shared.DDD.BuildingBlocks;

internal sealed class EventMapper : IEventMapper
{
    public List<IntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map).ToList();
    }

    private static IntegrationEvent? Map(IDomainEvent @event)
    {
        return @event switch
        {
            InquiryMadeDomainEvent domainEvent =>
                new InquiryMadeEvent(
                    domainEvent.InquiryId.Value),
            _ => null
        };
    }
}
