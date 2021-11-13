using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Payments;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentInitialized.Configuration;
using PaymentInitialized.Sender;

internal static class EmailPaymentsModule
{
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddScoped<IPaymentInitializedMailConfiguration, PaymentInitializedMailConfiguration>();
        services.AddScoped<IPaymentInitializedSender, PaymentInitializedSender>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
