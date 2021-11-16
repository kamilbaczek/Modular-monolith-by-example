namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Domain.Payments;
using Shared.DDD.ValueObjects;
using Stripe;
using Card = Domain.Payments.Card;


public sealed class PaymentProcessor : IPaymentProcessor
{
    public void Pay(PaymentSecret paymentSecret,
        string name,
        string cardNumber,
        long expMonth,
        long expYear, 
        string security)
    {
        var paymentMethodCreateOptions = new PaymentMethodCreateOptions
        {
            Type = "card",
            Card = new PaymentMethodCardOptions
            {
                Cvc = security,
                ExpMonth = expMonth,
                ExpYear = expYear,
                Number = cardNumber
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
            Amount = (long)1231233, 
            Currency = amountToPay.Currency.ToLower()
        };
        var paymentIntent = paymentIntentService.Create(options);
        
        return PaymentSecret.Of(paymentIntent.ClientSecret);
    }
}
