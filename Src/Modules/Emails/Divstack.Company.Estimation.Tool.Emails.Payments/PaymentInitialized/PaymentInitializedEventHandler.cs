namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using NServiceBus;
using Sender;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class
    PaymentInitializedEventHandler : IHandleMessages<PaymentInitialized>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentInitializedSender _paymentInitializedSender;

    internal PaymentInitializedEventHandler(IPaymentInitializedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }

    public async Task Handle(PaymentInitialized paymentInitialized, IMessageHandlerContext context)
    {
        var (firstName, lastName, email, _, _) = await GetClientInfo(paymentInitialized);
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
