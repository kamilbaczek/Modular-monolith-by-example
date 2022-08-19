namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events.Publish.Mapper;

using Domain.Payments.Events;
using IntegrationsEvents.External;
using Shared.DDD.BuildingBlocks;

internal sealed class EventMapper : IEventMapper
{
    public List<IIntegrationEvent?> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map).ToList();
    }

    private static IIntegrationEvent? Map(IDomainEvent @event)
    {
        return @event switch
        {
            PaymentInitializedDomainEvent domainEvent =>
                new PaymentInitialized(
                    domainEvent.PaymentId.Value,
                    domainEvent.ValuationId.Value,
                    domainEvent.InquiryId.Value,
                    domainEvent.AmountToPay.Value,
                    domainEvent.AmountToPay.Currency),
            PaymentCompletedDomainEvent domainEvent =>
                new PaymentCompleted(
                    domainEvent.PaymentId.Value,
                    domainEvent.InquiryId.Value),
            _ => null
        };
    }
}
