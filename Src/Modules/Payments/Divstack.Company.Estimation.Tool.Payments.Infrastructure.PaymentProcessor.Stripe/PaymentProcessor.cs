namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe;

using Actions.Initialize;
using Actions.Pay;
using Domain.Payments;
using Shared.DDD.ValueObjects;

internal sealed class PaymentProcessor : IPaymentProcessor
{
    private readonly IPaymentConfirmation _paymentConfirmation;
    private readonly IPaymentInitializer _paymentInitializer;

    public PaymentProcessor(IPaymentInitializer paymentInitializer,
        IPaymentConfirmation paymentConfirmation)
    {
        _paymentInitializer = paymentInitializer;
        _paymentConfirmation = paymentConfirmation;
    }

    public async Task PayAsync(PaymentSecret paymentSecret, Card card, CancellationToken cancellationToken = default) =>
        await _paymentConfirmation.ConfirmAsync(paymentSecret, card, cancellationToken);

    public async Task<PaymentSecret> InitializeAsync(Money amountToPay, CancellationToken cancellationToken = default) =>
        await _paymentInitializer.InitializeAsync(amountToPay, cancellationToken);
}
