namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Pay;

using Ardalis.GuardClauses;
using Common.Services.PaymentIntent;
using Common.Services.PaymentMethod;
using Domain.Payments;
using global::Stripe;
using Card = Domain.Payments.Card;

internal sealed class PaymentConfirmation : IPaymentConfirmation
{
    private const string Card = "card";
    private readonly IPaymentIntentStripeService _paymentIntentStripeService;
    private readonly IPaymentMethodStripeService _paymentMethodStripeService;

    public PaymentConfirmation(IPaymentIntentStripeService paymentIntentStripeService, IPaymentMethodStripeService paymentMethodStripeService)
    {
        _paymentIntentStripeService = paymentIntentStripeService;
        _paymentMethodStripeService = paymentMethodStripeService;
    }
    
    public async Task ConfirmAsync(PaymentSecret paymentSecret, Card card, CancellationToken cancellationToken = default)
    {
        var paymentMethodCreateOptions = CreateCardPaymentMethodRequest(card);
        var paymentMethod = await _paymentMethodStripeService.CreateAsync(paymentMethodCreateOptions, cancellationToken: cancellationToken);
        
        var paymentIntentConfirmOptions = GetPaymentIntentConfirmOptions(paymentMethod);
        await _paymentIntentStripeService.ConfirmAsync(
            paymentSecret.Value,
            paymentIntentConfirmOptions, 
            cancellationToken: cancellationToken);
    }
    
    private static PaymentIntentConfirmOptions GetPaymentIntentConfirmOptions(PaymentMethod paymentMethod)
    {
        Guard.Against.Null(paymentMethod, nameof(paymentMethod));
        var getPaymentIntentConfirmOptions = new PaymentIntentConfirmOptions
        {
            PaymentMethod = paymentMethod.Id,
        };
        
        return getPaymentIntentConfirmOptions;
    }

    private static PaymentMethodCreateOptions CreateCardPaymentMethodRequest(Card card)
    {
        var paymentMethodCreateOptions = new PaymentMethodCreateOptions
        {
            Type = Card,
            Card = new PaymentMethodCardOptions
            {
                Cvc = card.Cvc,
                ExpMonth = card.ExpMonth,
                ExpYear = card.ExpYear,
                Number = card.Number
            }
        };
        
        return paymentMethodCreateOptions;
    }
}
