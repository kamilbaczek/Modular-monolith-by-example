using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested
{
    internal sealed class ProposalSuggestedEventHandler : INotificationHandler<ProposalSuggested>
    {
        private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;
        private readonly IInquiriesModule _inquiriesModule;

        public ProposalSuggestedEventHandler(IValuationProposalSuggestedMailSender proposalSuggestedMailSender,
            IInquiriesModule inquiriesModule)
        {
            _proposalSuggestedMailSender = proposalSuggestedMailSender;
            _inquiriesModule = inquiriesModule;
        }

        public async Task Handle(ProposalSuggested proposalSuggestedDomainEvent, CancellationToken cancellationToken)
        {
            var client = await GetClientInfo(proposalSuggestedDomainEvent);
            var request = new ValuationProposalSuggestedEmailRequest(
                proposalSuggestedDomainEvent.ValuationId,
                proposalSuggestedDomainEvent.ProposalId,
                proposalSuggestedDomainEvent.InquiryId,
                client.FullName,
                client.Email,
                proposalSuggestedDomainEvent.Value,
                proposalSuggestedDomainEvent.Currency,
                proposalSuggestedDomainEvent.Description);
            await _proposalSuggestedMailSender.SendAsync(request);
        }

        private async Task<InquiryClientDto> GetClientInfo(ProposalSuggested proposalSuggestedDomainEvent)
        {
            var inquiryClientQuery = new GetInquiryClientQuery(proposalSuggestedDomainEvent.InquiryId);
            var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
            return client;
        }
    }
}