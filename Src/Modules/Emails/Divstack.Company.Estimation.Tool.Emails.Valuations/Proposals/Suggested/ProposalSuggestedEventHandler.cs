using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested
{
    internal sealed class ProposalSuggestedEventHandler : INotificationHandler<ProposalSuggested>
    {
        private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;

        public ProposalSuggestedEventHandler(IValuationProposalSuggestedMailSender proposalSuggestedMailSender)
        {
            _proposalSuggestedMailSender = proposalSuggestedMailSender;
        }

        public Task Handle(ProposalSuggested proposalSuggestedDomainEvent, CancellationToken cancellationToken)
        {
            var request = new ValuationProposalSuggestedEmailRequest(
                proposalSuggestedDomainEvent.FullName,
                proposalSuggestedDomainEvent.ClientEmail,
                proposalSuggestedDomainEvent.ValuationId,
                proposalSuggestedDomainEvent.ProposalId,
                proposalSuggestedDomainEvent.Value,
                proposalSuggestedDomainEvent.Currency,
                proposalSuggestedDomainEvent.Description);
             _proposalSuggestedMailSender.Send(request);

             return Task.CompletedTask;
        }
    }
}
