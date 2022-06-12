namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using NServiceBus;
using Sender;
using Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalSuggestedEventHandler : IHandleMessages<ProposalSuggested>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IValuationProposalSuggestedMailSender _proposalSuggestedMailSender;

    public ProposalSuggestedEventHandler(IValuationProposalSuggestedMailSender proposalSuggestedMailSender,
        IInquiriesModule inquiriesModule)
    {
        _proposalSuggestedMailSender = proposalSuggestedMailSender;
        _inquiriesModule = inquiriesModule;
    }

    public async Task Handle(ProposalSuggested proposalSuggested, IMessageHandlerContext context)
    {
        var client = await GetClientInfo(proposalSuggested);
        var request = new ValuationProposalSuggestedEmailRequest(
            proposalSuggested.ValuationId,
            proposalSuggested.ProposalId,
            proposalSuggested.InquiryId,
            client.FullName,
            client.Email,
            proposalSuggested.Value,
            proposalSuggested.Currency,
            proposalSuggested.Description);
        await _proposalSuggestedMailSender.SendAsync(request);
    }

    private async Task<InquiryClientDto> GetClientInfo(ProposalSuggested proposalSuggestedDomainEvent)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(proposalSuggestedDomainEvent.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
        return client;
    }
}
