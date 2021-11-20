namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Initialize;

using Common.Services.PaymentIntent;
using Domain.Payments;
using global::Stripe;
using Shared.DDD.ValueObjects;

internal sealed class PaymentInitializer : IPaymentInitializer
{
    private readonly IPaymentIntentStripeService _paymentIntentStripeService;
    public PaymentInitializer(IPaymentIntentStripeService paymentIntentStripeService)
    {
        _paymentIntentStripeService = paymentIntentStripeService;
    }
    private const string Manual = "manual";
    public async Task<PaymentSecret> InitializeAsync(Money amountToPay, CancellationToken cancellationToken = default)
    {
        var value = (long)(amountToPay.Value ?? 0);
        var options = GetPaymentIntentCreateOptions(amountToPay, value);
        var paymentIntent = await _paymentIntentStripeService.CreateAsync(options, cancellationToken: cancellationToken);
        
        return PaymentSecret.Of(paymentIntent.Id);
    }
    
    private static PaymentIntentCreateOptions GetPaymentIntentCreateOptions(Money amountToPay, long value)
    {
        var options = new PaymentIntentCreateOptions
        {
            ConfirmationMethod = Manual,
            Amount = value,
            Currency = amountToPay.Currency.ToLower()
        };
        
        return options;
    }
}
