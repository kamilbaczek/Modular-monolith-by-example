namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized;

using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using Inquiries.Application.Inquiries.Queries.GetClient.Dtos;
using Sender;
using Shared.Infrastructure.EventBus.Subscribe;
using Tool.Payments.IntegrationsEvents.External;

internal sealed class
    PaymentInitializedEventHandler : IIntegrationEventHandler<PaymentInitialized>
{
    private readonly IInquiriesModule _inquiriesModule;
    private readonly IPaymentInitializedSender _paymentInitializedSender;

    public PaymentInitializedEventHandler(IPaymentInitializedSender paymentInitializedSender,
        IInquiriesModule inquiriesModule)
    {
        _paymentInitializedSender = paymentInitializedSender;
        _inquiriesModule = inquiriesModule;
    }
    public async ValueTask Handle(PaymentInitialized proposalApprovedEvent, CancellationToken cancellationToken)
    {
        var (firstName, lastName, email, _, _) = await GetClientInfo(proposalApprovedEvent);
        var paymentInitializedEmailRequest = new PaymentInitializedEmailRequest(
            firstName,
            lastName,
            proposalApprovedEvent.AmountToPayCurrency,
            proposalApprovedEvent.AmountToPayValue,
            email,
            proposalApprovedEvent.PaymentId);
        _paymentInitializedSender.Send(paymentInitializedEmailRequest);
    }

    private async Task<InquiryClientDto> GetClientInfo(PaymentInitialized paymentInitialized)
    {
        var inquiryClientQuery = new GetInquiryClientQuery(paymentInitialized.InquiryId);
        var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);

        return client;
    }
}
