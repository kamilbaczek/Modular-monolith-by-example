namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Pay;

using Domain.Payments;

internal interface IPaymentConfirmation
{
    Task ConfirmAsync(PaymentSecret paymentSecret, Card card, CancellationToken cancellationToken = default);
}
