namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public interface IPaymentsRepository
{
    Task PersistAsync(Payment payment, CancellationToken cancellationToken = default);
    Task<Payment?> GetAsync(PaymentId paymentId, CancellationToken cancellationToken = default);
}
