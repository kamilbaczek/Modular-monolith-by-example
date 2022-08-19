namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Initialize;

using Domain.Payments;
using Shared.DDD.ValueObjects;

internal interface IPaymentInitializer
{
    public Task<PaymentSecret> InitializeAsync(Money amountToPay, CancellationToken cancellationToken = default);
}
