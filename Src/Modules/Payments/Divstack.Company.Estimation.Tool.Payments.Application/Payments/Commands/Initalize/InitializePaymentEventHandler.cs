namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Initalize;

using Common.Interfaces;
using Domain.Payments;
using MediatR;
using Shared.DDD.ValueObjects;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class InitializePaymentEventHandler : INotificationHandler<ValuationCompleted>
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
    public async Task Handle(ValuationCompleted @event, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(@event.ValuationId);
        var inquiryId = InquiryId.Of(@event.InquiryId);
        var amountToPay = Money.Of(@event.AmountToPayValue, @event.AmountToPayCurrency);
        var payment = Payment.Initialize(valuationId, inquiryId, amountToPay, _paymentProcessor);

        await _paymentsRepository.PersistAsync(payment, cancellationToken);
        await _integrationEventPublisher.Publish(payment.DomainEvents, cancellationToken);
    }
}
