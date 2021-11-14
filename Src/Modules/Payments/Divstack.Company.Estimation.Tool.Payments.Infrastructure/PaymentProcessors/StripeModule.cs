namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Domain.Payments;
using Stripe;

internal static class StripeModule
{
    internal static IServiceCollection AddStripe(this IServiceCollection services)
    {
        StripeConfiguration.ApiKey = "sk_test_51JugBiJSvuPHECEKdZPPvIPgGnX0Y2gCNrV02unAGTvYbJ4WRkMogU9bqT3eaWwfcyLTwXSvelCLOE6k2PXKDzea00vtjx5H3l";
        services.AddScoped<IPaymentProcessor, PaymentProcessor>();

        return services;
    }
}
