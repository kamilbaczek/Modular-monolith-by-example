namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using MediatR;
using Sender;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class
    PaymentInitializedEventHandler : INotificationHandler<PaymentInitialized>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentInitializedSender _paymentInitializedSender;

    public PaymentInitializedEventHandler(IPaymentInitializedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }
    public async Task Handle(PaymentInitialized paymentInitialized, CancellationToken cancellationToken)
    {
        var (firstName, lastName, email) = await GetClientInfo(paymentInitialized);
        var paymentInitializedEmailRequest = new PaymentInitializedEmailRequest(
            firstName,
            lastName,
            paymentInitialized.AmountToPayCurrency,
            paymentInitialized.AmountToPayValue,
            email,
            paymentInitialized.PaymentId);
        _paymentInitializedSender.Send(paymentInitializedEmailRequest);
    }

    private async Task<InquiryClientDto> GetClientInfo(PaymentInitialized paymentInitialized)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(paymentInitialized.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
        return client;
    }
}
