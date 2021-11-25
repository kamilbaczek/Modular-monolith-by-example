[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Payments;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentInitialized;

internal static class EmailPaymentsModule
{
    private const string Configuration = "Configuration";
    private const string Sender = "Sender";
    internal static IServiceCollection AddPayments(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Scan(scan => scan.FromAssemblyOf<PaymentInitializedEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        services.Scan(scan => scan.FromAssemblyOf<PaymentInitializedEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Sender)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;

        return services;
    }
}
