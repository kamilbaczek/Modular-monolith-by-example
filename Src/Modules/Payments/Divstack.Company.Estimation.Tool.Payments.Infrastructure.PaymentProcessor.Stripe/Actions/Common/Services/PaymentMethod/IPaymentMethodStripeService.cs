namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Actions.Common.Services.PaymentMethod;

using global::Stripe;

internal interface IPaymentMethodStripeService
{
    Task<PaymentMethod> CreateAsync(PaymentMethodCreateOptions options, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
}
