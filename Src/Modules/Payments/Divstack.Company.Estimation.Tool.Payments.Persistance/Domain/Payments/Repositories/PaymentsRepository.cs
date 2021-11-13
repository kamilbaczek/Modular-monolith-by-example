namespace Divstack.Company.Estimation.Tool.Payments.Persistance.Domain.Payments.Repositories;

using Tool.Payments.Domain.Payments;

internal sealed class PaymentsRepository : IPaymentsRepository
{
    private readonly ICollection<Payment> _payments = new List<Payment>();
    public Task PersistAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        _payments.Add(payment);

        return Task.CompletedTask;
    }
    public Task<Payment?> GetByIdAsync(PaymentId paymentId, CancellationToken cancellationToken = default)
    {
        var payment = _payments.SingleOrDefault(payment => payment.PaymentId == paymentId);
        return Task.FromResult(payment);
    }
}
