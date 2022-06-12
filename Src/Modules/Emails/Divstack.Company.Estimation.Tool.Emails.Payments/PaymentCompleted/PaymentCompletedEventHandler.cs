namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using MassTransit;
using Sender;
using Tool.Payments.IntegrationsEvents.External;

public sealed class
    PaymentCompletedEventHandler : IConsumer<PaymentCompleted>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentCompletedSender _paymentInitializedSender;

    internal PaymentCompletedEventHandler(IPaymentCompletedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }

    public async Task Consume(ConsumeContext<PaymentCompleted> context)
    {
        var paymentCompleted = context.Message;
        var (firstName, lastName, email, _, _) = await GetClientInfo(paymentCompleted);
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
