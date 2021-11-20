namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public interface IPaymentProcessor
{
    Task PayAsync(PaymentSecret paymentSecret, Card card, CancellationToken cancellationToken = default);
    Task<PaymentSecret> InitializeAsync(Money amountToPay, CancellationToken cancellationToken = default);
}
