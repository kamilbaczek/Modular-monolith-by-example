namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Microsoft.AspNetCore.Builder;
using PaymentProcessor.Stripe;

internal static class PaymentProcessorsModule
{
    internal static IServiceCollection AddPaymentsProcessors(this IServiceCollection services)
    {
        services.AddStripe();

        return services;
    }

    internal static void UsePaymentProcessors(this IApplicationBuilder app)
    {
        app.UseStripe();
    }
}
