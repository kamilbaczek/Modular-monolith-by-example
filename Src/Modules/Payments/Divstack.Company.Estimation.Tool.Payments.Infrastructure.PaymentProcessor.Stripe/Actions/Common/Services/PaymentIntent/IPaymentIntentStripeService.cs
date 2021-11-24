namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Common.Services.PaymentIntent;

using global::Stripe;

internal interface IPaymentIntentStripeService
{
    Task<PaymentIntent> ConfirmAsync(string id, PaymentIntentConfirmOptions? options = null, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
    Task<PaymentIntent> CreateAsync(PaymentIntentCreateOptions options, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
}
