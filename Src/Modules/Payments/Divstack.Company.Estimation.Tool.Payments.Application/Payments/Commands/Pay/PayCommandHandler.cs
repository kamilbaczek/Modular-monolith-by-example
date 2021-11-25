namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Exceptions;

internal sealed class PayCommandHandler : IRequestHandler<PayCommand>
{
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IPaymentsRepository _paymentsRepository;

    public PayCommandHandler(IPaymentsRepository paymentsRepository,
        IPaymentProcessor paymentProcessor)
    {
        _paymentsRepository = paymentsRepository;
        _paymentProcessor = paymentProcessor;
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

        return Unit.Value;
    }
}
