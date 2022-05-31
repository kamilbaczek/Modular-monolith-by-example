namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Sender;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalSuggestedEventHandler : IIntegrationEventHandler<ProposalSuggested>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;

    public ProposalSuggestedEventHandler(IValuationProposalSuggestedMailSender proposalSuggestedMailSender,
        IInquiriesModule inquiriesModule)
    {
        _proposalSuggestedMailSender = proposalSuggestedMailSender;
        _inquiriesModule = inquiriesModule;
    }

    public async ValueTask Handle(ProposalSuggested proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var client = await GetClientInfo(proposalApprovedEvent);
        var request = new ValuationProposalSuggestedEmailRequest(
            proposalApprovedEvent.ValuationId,
            proposalApprovedEvent.ProposalId,
            proposalApprovedEvent.InquiryId,
            client.FullName,
            client.Email,
            proposalApprovedEvent.Value,
            proposalApprovedEvent.Currency,
            proposalApprovedEvent.Description);
        await _proposalSuggestedMailSender.SendAsync(request);
    }

    private async Task<InquiryClientDto> GetClientInfo(ProposalSuggested proposalSuggestedDomainEvent)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(proposalSuggestedDomainEvent.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
        return client;
    }
}
