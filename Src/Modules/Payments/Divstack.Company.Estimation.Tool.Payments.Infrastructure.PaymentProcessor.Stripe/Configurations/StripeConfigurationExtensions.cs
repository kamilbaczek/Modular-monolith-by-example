namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.Configurations;

using global::Stripe;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal static class StripeConfigurationExtensions
{
    internal static void ConfigureStripe(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
        var stripeConfiguration = new StripeApiConfiguration(configuration);
        StripeConfiguration.ApiKey = stripeConfiguration.ApiKey;
    }
}
