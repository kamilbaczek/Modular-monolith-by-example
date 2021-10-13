using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;
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

        public async Task Handle(ProposalSuggested proposalSuggestedDomainEvent, CancellationToken cancellationToken)
        {
            var request = new ValuationProposalSuggestedEmailRequest(
                proposalSuggestedDomainEvent.ValuationId,
                proposalSuggestedDomainEvent.ProposalId,
                proposalSuggestedDomainEvent.InquiryId,
                proposalSuggestedDomainEvent.Value,
                proposalSuggestedDomainEvent.Currency,
                proposalSuggestedDomainEvent.Description);
            await _proposalSuggestedMailSender.SendAsync(request);
        }
    }
}