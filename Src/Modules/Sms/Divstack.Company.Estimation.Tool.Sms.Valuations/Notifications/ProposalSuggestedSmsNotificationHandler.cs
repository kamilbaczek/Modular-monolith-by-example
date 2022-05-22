namespace Divstack.Estimation.Tool.Sms.Valuations.Notifications;

using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;
using Company.Estimation.Tool.Sms.Core.Clients;
using Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class ProposalSuggestedSmsNotificationHandler : IIntegrationEventHandler<ProposalSuggested>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly ISmsClient _smsClient;
    public ProposalSuggestedSmsNotificationHandler(ISmsClient smsClient, IInquiriesModule inquiriesModule)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
    }
    public async ValueTask Handle(ProposalSuggested proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var query = new GetInquiryClientQuery(proposalApprovedEvent.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);
        var message = GetShortMessage(proposalApprovedEvent.ValuationId, proposalApprovedEvent.Value, proposalApprovedEvent.Currency, proposalApprovedEvent.Description);

        await _smsClient.SendAsync(message, client.PhoneNumber, cancellationToken);
    }

    private static string GetShortMessage(Guid inquiryId, decimal? value, string currency, string description)
    {
        return $"Suggested proposal for inquiry '{inquiryId}' suggested price {value} {currency}. {description}";
    }
}
