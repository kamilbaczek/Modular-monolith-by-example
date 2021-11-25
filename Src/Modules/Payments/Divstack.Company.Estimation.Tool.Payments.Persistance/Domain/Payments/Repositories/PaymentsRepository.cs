namespace Divstack.Company.Estimation.Tool.Payments.Persistance.Domain.Payments.Repositories;

using DataAccess;
using MongoDB.Driver;
using Tool.Payments.Domain.Payments;

internal sealed class PaymentsRepository : IPaymentsRepository
{
    private readonly IPaymentsContext _paymentsContext;

    public PaymentsRepository(IPaymentsContext paymentsContext)
    {
        _paymentsContext = paymentsContext;
    }

    public async Task<Payment?> GetAsync(PaymentId paymentId, CancellationToken cancellationToken = default)
    {
        return await _paymentsContext.Payments
            .Find(payment => payment.Id == paymentId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task PersistAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        await _paymentsContext.Payments.InsertOneAsync(payment, cancellationToken: cancellationToken);
    }

    public async Task CommitAsync(Payment payment, CancellationToken cancellationToken = default)
    {
        await _paymentsContext.Payments.ReplaceOneAsync(paymentInDb => paymentInDb.Id == payment.Id,
            payment, cancellationToken: cancellationToken);
    }
}
