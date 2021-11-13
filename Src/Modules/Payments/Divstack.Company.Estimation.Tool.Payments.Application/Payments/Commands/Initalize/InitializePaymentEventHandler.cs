namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Initalize;

using Common.Interfaces;
using Domain.Payments;
using MediatR;
using Shared.DDD.ValueObjects;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class InitializePaymentEventHandler : INotificationHandler<ValuationCompleted>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IPaymentsRepository _paymentsRepository;
    public InitializePaymentEventHandler(IPaymentsRepository paymentsRepository,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _paymentsRepository = paymentsRepository;
        _integrationEventPublisher = integrationEventPublisher;
    }
    public async Task Handle(ValuationCompleted @event, CancellationToken cancellationToken)
    {
        var valuationId = ValuationId.Of(@event.ValuationId);
        var inquiryId = InquiryId.Of(@event.InquiryId);
        var amountToPay = Money.Of(@event.AmountToPayValue, @event.AmountToPayCurrency);
        var payment = Payment.Initialize(valuationId, inquiryId, amountToPay);

        await _paymentsRepository.PersistAsync(payment, cancellationToken);
        _integrationEventPublisher.Publish(payment.DomainEvents);
    }
}
