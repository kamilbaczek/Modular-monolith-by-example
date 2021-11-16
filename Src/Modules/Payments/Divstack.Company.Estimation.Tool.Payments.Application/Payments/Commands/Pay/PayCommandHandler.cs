namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Exceptions;

internal sealed class PayCommandHandler : IRequestHandler<PayCommand>
{
    private readonly IPaymentsRepository _paymentsRepository;
    private readonly IPaymentProcessor _paymentProcessor;

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
        payment.Pay(_paymentProcessor, 
            command.Name, 
            command.CardNumber, 
            command.ExpMonth, 
            command.ExpYear,
            command.Security);

        return Unit.Value;
    }
}
