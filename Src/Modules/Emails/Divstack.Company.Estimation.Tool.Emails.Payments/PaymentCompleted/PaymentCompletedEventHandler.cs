namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Sender;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class
    PaymentCompletedEventHandler : IIntegrationEventHandler<PaymentCompleted>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentCompletedSender _paymentInitializedSender;

    public PaymentCompletedEventHandler(IPaymentCompletedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }

    public async ValueTask Handle(PaymentCompleted proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var (firstName, lastName, email, _, _) = await GetClientInfo(proposalApprovedEvent);
        var paymentInitializedEmailRequest = new PaymentCompletedEmailRequest(
            firstName,
            lastName,
            email,
            proposalApprovedEvent.PaymentId);
        _paymentInitializedSender.Send(paymentInitializedEmailRequest);
    }

    private async Task<InquiryClientDto> GetClientInfo(PaymentCompleted paymentInitialized)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(paymentInitialized.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);
        return client;
    }
}
