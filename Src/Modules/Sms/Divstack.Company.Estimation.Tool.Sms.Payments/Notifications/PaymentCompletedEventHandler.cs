namespace Divstack.Estimation.Tool.Sms.Payments.Notifications;

using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Payments.IntegrationsEvents.External;
using Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe;
using Company.Estimation.Tool.Sms.Core.Clients;

internal sealed class PaymentCompletedEventHandler : IIntegrationEventHandler<PaymentCompleted>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly ISmsClient _smsClient;
    public PaymentCompletedEventHandler(ISmsClient smsClient,
        IInquiriesModule inquiriesModule)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
    }

    public async ValueTask Handle(PaymentCompleted proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var (paymentId, inquiryId) = proposalApprovedEvent;
        var query = new GetInquiryClientQuery(inquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);
        var message = GetShortMessage(paymentId);

        await _smsClient.SendAsync(message, client.PhoneNumber, cancellationToken);
    }
    private static string GetShortMessage(Guid paymentId)
    {
        return $"Estimation tool - payment '{paymentId}' completed";
    }
}
