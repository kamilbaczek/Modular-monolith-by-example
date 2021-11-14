namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Domain.Payments;
using Shared.DDD.ValueObjects;
using Stripe;
using Card = Domain.Payments.Card;


public sealed class PaymentProcessor : IPaymentProcessor
{
    public void Pay(PaymentSecret paymentSecret, string token)
    {
        var paymentMethodCreateOptions = new PaymentMethodCreateOptions
        {
            Type = "card",
            Card = new PaymentMethodCardOptions
            {
                Token = token
            },
        };
        var paymentMethodService = new PaymentMethodService();
        var paymentMethod = paymentMethodService.Create(paymentMethodCreateOptions);

        var options = new PaymentIntentConfirmOptions
        {
            PaymentMethod = paymentMethod.Id,
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
