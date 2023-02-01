namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Initalize;

using Common.IntegrationsEvents;
using NServiceBus;
using Shared.DDD.ValueObjects;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class InitializePaymentEventHandler : IHandleMessages<ValuationCompleted>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IPaymentsRepository _paymentsRepository;
    public InitializePaymentEventHandler(IPaymentsRepository paymentsRepository,
        IIntegrationEventPublisher integrationEventPublisher,
        IPaymentProcessor paymentProcessor)
    {
        _paymentsRepository = paymentsRepository;
        _integrationEventPublisher = integrationEventPublisher;
        _paymentProcessor = paymentProcessor;
    }

    public async Task Handle(ValuationCompleted valuationCompleted, IMessageHandlerContext context)
    {
        var valuationId = ValuationId.Of(valuationCompleted.ValuationId);
        var inquiryId = InquiryId.Of(valuationCompleted.InquiryId);
        var amountToPay = Money.Of(valuationCompleted.AmountToPayValue, valuationCompleted.AmountToPayCurrency);

        var payment = await Payment.InitializeAsync(valuationId, inquiryId, amountToPay, _paymentProcessor);

        await _paymentsRepository.PersistAsync(payment, context.CancellationToken);
        await _integrationEventPublisher.PublishAsync(payment.DomainEvents, context.CancellationToken);
    }
}
