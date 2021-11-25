namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using MediatR;
using Sender;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalSuggestedEventHandler : INotificationHandler<ProposalSuggested>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;

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
