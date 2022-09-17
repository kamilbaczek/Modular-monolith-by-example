namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe;

using Actions.Common.Services.PaymentIntent;
using Actions.Common.Services.PaymentMethod;
using Actions.Initialize;
using Actions.Pay;
using Configurations;
using Domain.Payments;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class StripeModule
{
    public static IServiceCollection AddStripe(this IServiceCollection services)
    {
        services.AddScoped<IPaymentProcessor, PaymentProcessor>();
        services.AddScoped<IPaymentInitializer, PaymentInitializer>();
        services.AddScoped<IPaymentConfirmation, PaymentConfirmation>();
        services.AddScoped<IPaymentIntentStripeService, PaymentIntentStripeService>();
        services.AddScoped<IPaymentMethodStripeService, PaymentMethodStripeService>();

        return services;
    }

    public static void UseStripe(this IApplicationBuilder app) =>
        app.ConfigureStripe();
}
