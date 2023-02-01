namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish.Mapper;

using Domain.Valuations.Events;
using Domain.Valuations.Proposals.Events;
using IntegrationsEvents.ExternalEvents;
using Shared.DDD.BuildingBlocks;

internal sealed class EventMapper : IEventMapper
{
    public IReadOnlyCollection<IIntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map)
            .Where(@event => @event is not null)
            .ToList()!;
    }

    private static IIntegrationEvent? Map(IDomainEvent @event)
    {
        return @event switch
        {
            ProposalApprovedDomainEvent domainEvent =>
                new ProposalApproved(domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.SuggestedBy.Value,
                    domainEvent.Price.Currency,
                    domainEvent.Price.Value),
            ProposalCancelledDomainEvent domainEvent =>
                new ProposalCancelled(domainEvent.CancelledBy.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.ValuationId.Value),
            ProposalRejectedDomainEvent domainEvent =>
                new ProposalRejected(
                    domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.Value.Value,
                    domainEvent.Value.Currency),
            ProposalSuggestedDomainEvent domainEvent =>
                new ProposalSuggested(
                    domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.InquiryId.Value,
                    domainEvent.Price.Value,
                    domainEvent.Price.Currency,
                    domainEvent.Description.Message),
            ValuationRequestedDomainEvent domainEvent =>
                new ValuationRequested(
                    domainEvent.InquiryId.Value,
                    domainEvent.ValuationId.Value),
            ValuationCompletedDomainEvent domainEvent =>
                new ValuationCompleted(
                    domainEvent.InquiryId.Value,
                    domainEvent.ValuationId.Value,
                    domainEvent.Price.Value,
                    domainEvent.Price.Currency),
            _ => null
        };
    }
}
