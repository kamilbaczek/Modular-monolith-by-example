namespace Divstack.Estimation.Tool.Sms.Valuations.Notifications;

using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Sms.Core.Clients;
using Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;
using MediatR;

internal sealed class ProposalSuggestedSmsNotificationHandler : INotificationHandler<ProposalSuggested>
{
    private readonly ISmsClient _smsClient;
    private readonly IInquiriesModule _inquiriesModule;
    private static string GetShortMessage(Guid inquiryId) => $"Estimation tool - suggested proposal for inquiry '{inquiryId}'";
    public ProposalSuggestedSmsNotificationHandler(ISmsClient smsClient, IInquiriesModule inquiriesModule)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
    }
    public  async Task Handle(ProposalSuggested notification, CancellationToken cancellationToken)
    {
        var query = new GetInquiryClientQuery(notification.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);
        var message = GetShortMessage(notification.ValuationId);

        await _smsClient.SendAsync(message, client.PhoneNumber, cancellationToken: cancellationToken);
    }
}
