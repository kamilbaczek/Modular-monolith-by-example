namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using MediatR;
using Sender;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class
    PaymentCompletedEventHandler : INotificationHandler<PaymentCompleted>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentCompletedSender _paymentInitializedSender;

    public PaymentCompletedEventHandler(IPaymentCompletedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }
    
    public async Task Handle(PaymentCompleted paymentCompleted, CancellationToken cancellationToken)
    {
        var (firstName, lastName, email) = await GetClientInfo(paymentCompleted);
        var paymentInitializedEmailRequest = new PaymentCompletedEmailRequest(
            firstName,
            lastName,
            email,
            paymentCompleted.PaymentId);
        _paymentInitializedSender.Send(paymentInitializedEmailRequest);
    }

    private async Task<InquiryClientDto> GetClientInfo(PaymentCompleted paymentInitialized)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(paymentInitialized.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
        return client;
    }
}
