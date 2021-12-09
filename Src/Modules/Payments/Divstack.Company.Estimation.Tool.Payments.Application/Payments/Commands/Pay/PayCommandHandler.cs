namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Exceptions;
using Common.IntegrationsEvents;

internal sealed class PayCommandHandler : IRequestHandler<PayCommand>
{
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IPaymentsRepository _paymentsRepository;

    public PayCommandHandler(IPaymentsRepository paymentsRepository,
        IPaymentProcessor paymentProcessor,
        IIntegrationEventPublisher integrationEventPublisher)
    {
        _paymentsRepository = paymentsRepository;
        _paymentProcessor = paymentProcessor;
        _integrationEventPublisher = integrationEventPublisher;
    }

    public async Task<Unit> Handle(PayCommand command, CancellationToken cancellationToken)
    {
        var paymentId = PaymentId.Of(command.PaymentId);
        var payment = await _paymentsRepository.GetAsync(paymentId, cancellationToken);
        if (payment is null)
        {
            throw new NotFoundException(command.PaymentId, nameof(Payment));
        }

        var card = Card.New(
            command.Card.CardNumber,
            command.Card.ExpMonth,
            command.Card.ExpYear,
            command.Card.Cvc);
        await payment.PayCard(_paymentProcessor, card);
        await _integrationEventPublisher.PublishAsync(payment.DomainEvents, cancellationToken);

        return Unit.Value;
    }
}
