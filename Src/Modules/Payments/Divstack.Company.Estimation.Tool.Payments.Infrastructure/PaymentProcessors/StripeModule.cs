namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessors;

using Domain.Payments;

internal static class StripeModule
{
    internal static IServiceCollection AddStripe(this IServiceCollection services)
    {
        services.AddScoped<IPaymentProccessor, PaymentProccessor>();

        return services;
    }
}
