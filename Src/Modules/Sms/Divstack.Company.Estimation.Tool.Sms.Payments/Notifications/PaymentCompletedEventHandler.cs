namespace Divstack.Estimation.Tool.Sms.Payments.Notifications;

using Company.Estimation.Tool.Inquiries.Application.Common.Contracts;
using Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
using Company.Estimation.Tool.Payments.IntegrationsEvents.External;
using Company.Estimation.Tool.Sms.Core.Clients;
using MediatR;

internal sealed class PaymentCompletedEventHandler : INotificationHandler<PaymentCompleted>
{
    private readonly ISmsClient _smsClient;
    private readonly IInquiriesModule _inquiriesModule;
    private static string GetShortMessage(Guid paymentId) => $"Estimation tool - payment '{paymentId}' completed";
    public PaymentCompletedEventHandler(ISmsClient smsClient,
        IInquiriesModule inquiriesModule)
    {
        _smsClient = smsClient;
        _inquiriesModule = inquiriesModule;
    }

    public async Task Handle(PaymentCompleted notification, CancellationToken cancellationToken)
    {
        var (paymentId, inquiryId) = notification;
        var query = new GetInquiryClientQuery(inquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(query);
        var message = GetShortMessage(paymentId);

        await _smsClient.SendAsync(message, client.PhoneNumber, cancellationToken: cancellationToken);
    }
}
