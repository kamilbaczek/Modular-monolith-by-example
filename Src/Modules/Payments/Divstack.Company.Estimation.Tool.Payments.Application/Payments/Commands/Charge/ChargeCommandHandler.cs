namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Charge;

using Common.Exceptions;

internal sealed class ChargeCommandHandler : IRequestHandler<ChargeCommand>
{
    private readonly IPaymentsRepository _paymentsRepository;
    private readonly IPaymentProccessor _paymentProcessor;

    public ChargeCommandHandler(IPaymentsRepository paymentsRepository, 
        IPaymentProccessor paymentProcessor)
    {
        _paymentsRepository = paymentsRepository;
        _paymentProcessor = paymentProcessor;
    }

    public async Task<Unit> Handle(ChargeCommand command, CancellationToken cancellationToken)
    {
        var paymentId = new PaymentId(command.PaymentId);
        var payment = await _paymentsRepository.GetAsync(paymentId, cancellationToken);
        if (payment is null)
        {
            throw new NotFoundException(command.PaymentId, nameof(Payment));
        }
        
        payment.Charge(_paymentProcessor);

        return Unit.Value;
    }
}
