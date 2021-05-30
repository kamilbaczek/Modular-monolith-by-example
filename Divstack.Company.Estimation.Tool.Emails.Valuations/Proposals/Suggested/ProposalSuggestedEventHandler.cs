using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested
{
    internal sealed class ProposalSuggestedEventHandler : INotificationHandler<ProposalSuggestedEvent>
    {
        private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;

        public ProposalSuggestedEventHandler(IValuationProposalSuggestedMailSender proposalSuggestedMailSender)
        {
            _proposalSuggestedMailSender = proposalSuggestedMailSender;
        }

        public async Task Handle(ProposalSuggestedEvent proposalSuggestedEvent, CancellationToken cancellationToken)
        {
            var request = new ValuationProposalSuggestedEmailRequest(
                proposalSuggestedEvent.FullName,
                proposalSuggestedEvent.ClientEmail.Value,
                proposalSuggestedEvent.ValuationId.Value,
                proposalSuggestedEvent.ProposalId.Value,
                proposalSuggestedEvent.Value,
                proposalSuggestedEvent.Description.Message);
            await _proposalSuggestedMailSender.SendEmailAsync(request);
        }
    }
}
