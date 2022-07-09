namespace Divstack.Estimation.Tool.Sms.Valuations.Notifications.Proposals.ProposalSuggested;

using System.Web;
using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Sms.Core.Clients;
using Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using Configuration;
using NServiceBus;

internal sealed class ProposalSuggestedSmsNotificationHandler : IHandleMessages<ProposalSuggested>
{
    private const string ValuationIdPlaceholder = "{ValuationId}";
    private const string ProposalIdPlaceholder = "{ProposalId}";
    private readonly ISuggestValuationSmsConfiguration _configuration;

    private readonly IInquiriesModule _inquiriesModule;
    private readonly ISmsClient _smsClient;

    public ProposalSuggestedSmsNotificationHandler(ISmsClient smsClient,
        IInquiriesModule inquiriesModule,
        ISuggestValuationSmsConfiguration configuration)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
        _configuration = configuration;
    }

    public async Task Handle(ProposalSuggested proposalSuggested, IMessageHandlerContext context)
    {
        var query = new GetInquiryClientQuery(proposalSuggested.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);

        var acceptLink = GetAcceptLink(proposalSuggested);
        var rejectLink = GetRejectLink(proposalSuggested);

        var message = GetShortMessage(
            proposalSuggested.ValuationId,
            proposalSuggested.Value,
            proposalSuggested.Currency,
            proposalSuggested.Description,
            acceptLink,
            rejectLink);
        await _smsClient.SendAsync(message, client.PhoneNumber);
    }
    private string GetAcceptLink(ProposalSuggested proposalSuggested)
    {
        var valuationId = HttpUtility.UrlEncode(proposalSuggested.ValuationId.ToString());
        var proposalId = HttpUtility.UrlEncode(proposalSuggested.ProposalId.ToString());

        return _configuration.AcceptProposalLink
            .Replace(ValuationIdPlaceholder, valuationId)
            .Replace(ProposalIdPlaceholder, proposalId);
    }

    private string GetRejectLink(ProposalSuggested proposalSuggested)
    {
        var valuationId = HttpUtility.UrlEncode(proposalSuggested.ValuationId.ToString());
        var proposalId = HttpUtility.UrlEncode(proposalSuggested.ProposalId.ToString());

        return _configuration.RejectProposalLink
            .Replace(ValuationIdPlaceholder, valuationId)
            .Replace(ProposalIdPlaceholder, proposalId);
    }

    private static string GetShortMessage(
        Guid inquiryId,
        decimal? value,
        string currency,
        string description,
        string acceptLink,
        string rejectLink) =>
        $"Suggested proposal for inquiry '{inquiryId}' suggested price {value} {currency}. {description} {Environment.NewLine} Accept: {acceptLink} or Reject {rejectLink}";
}
