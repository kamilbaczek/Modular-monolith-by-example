namespace Divstack.Estimation.Tool.Sms.Valuations.Notifications;

using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Sms.Core.Clients;
using Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using NServiceBus;

internal sealed class ProposalSuggestedSmsNotificationHandler : IHandleMessages<ProposalSuggested>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly ISmsClient _smsClient;
    public ProposalSuggestedSmsNotificationHandler(ISmsClient smsClient, IInquiriesModule inquiriesModule)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
    }

    public async Task Handle(ProposalSuggested proposalSuggested, IMessageHandlerContext context)
    {
        var query = new GetInquiryClientQuery(proposalSuggested.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);
        var message = GetShortMessage(proposalSuggested.ValuationId, proposalSuggested.Value, proposalSuggested.Currency, proposalSuggested.Description);

        await _smsClient.SendAsync(message, client.PhoneNumber);
    }

    private static string GetShortMessage(Guid inquiryId, decimal? value, string currency, string description)
    {
        return $"Suggested proposal for inquiry '{inquiryId}' suggested price {value} {currency}. {description}";
    }
}
