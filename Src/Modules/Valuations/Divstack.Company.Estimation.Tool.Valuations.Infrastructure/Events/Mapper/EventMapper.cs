using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events.Mapper;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events
{
    internal sealed class EventMapper : IEventMapper
    {
        public IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events) =>
            events.Select(Map).ToList();

        private static IntegrationEvent Map(IDomainEvent @event)
            => @event switch
            {
                ProposalApprovedDomainEvent domainEvent =>
                    new ProposalApproved(domainEvent.ValuationId.Value,
                        domainEvent.ProposalId.Value,
                        domainEvent.SuggestedBy.Value,
                        domainEvent.Value.Currency,
                        domainEvent.Value.Value),
                ProposalCancelledDomainEvent domainEvent =>
                    new ProposalCancelled(domainEvent.CancelledBy.Value,
                        domainEvent.ProposalId.Value,
                        domainEvent.ValuationId.Value),
                ProposalRejectedDomainEvent domainEvent =>
                    new ProposalRejected(
                        domainEvent.ValuationId.Value,
                        domainEvent.ProposalId.Value,
                        domainEvent.Value.Value,
                        domainEvent.Value.Currency,
                        domainEvent.ClientEmail.Value),
                ProposalSuggestedDomainEvent domainEvent =>
                    new ProposalSuggested(
                        domainEvent.FullName,
                        domainEvent.ClientEmail.Value,
                        domainEvent.ValuationId.Value,
                        domainEvent.ProposalId.Value,
                        domainEvent.Value.Value,
                        domainEvent.Value.Currency,
                        domainEvent.Description.Message),
                ValuationDeadlineFixedDomainEvent domainEvent =>
                    new ValuationDeadlineFixed(
                        domainEvent.ValuationId.Value,
                        domainEvent.DeadlineDate.Date),
                ValuationCompletedDomainEvent domainEvent =>
                    new ValuationCompleted(
                        domainEvent.ClosedBy.Value,
                        domainEvent.ValuationId.Value),
                ValuationRequestedDomainEvent domainEvent =>
                    new ValuationRequested(
                        domainEvent.ValuationId.Value,
                        domainEvent.ServiceIds.Select(serviceId => serviceId.Value).ToList(),
                        domainEvent.ClientEmail.Value),
                _ => null
            };
    }
}
