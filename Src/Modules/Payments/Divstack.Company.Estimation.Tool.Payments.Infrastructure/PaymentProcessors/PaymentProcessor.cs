namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Domain.Payments;
using Shared.DDD.ValueObjects;
using Stripe;
using PaymentMethod = Domain.Payments.PaymentMethod;

public sealed class PaymentProcessor : IPaymentProcessor
{
    public void Pay(PaymentSecret paymentSecret, PaymentMethod paymentMethod)
    {
        var options = new PaymentIntentConfirmOptions
        {
            PaymentMethod = paymentMethod.Value
        };
        var service = new PaymentIntentService();
        service.Confirm(
            paymentSecret.Value,
            options
        );
    }
    public PaymentSecret Initialize(Money amountToPay)
    {
        var value = amountToPay.Value ?? 0;
        var paymentIntentService = new PaymentIntentService();
        var options = new PaymentIntentCreateOptions
        {
            ConfirmationMethod = "manual",
            Amount = (long)value, 
            Currency = amountToPay.Currency
        };
        var paymentIntent = paymentIntentService.Create(options);
        
        return PaymentSecret.Of(paymentIntent.ClientSecret);
    }
}
