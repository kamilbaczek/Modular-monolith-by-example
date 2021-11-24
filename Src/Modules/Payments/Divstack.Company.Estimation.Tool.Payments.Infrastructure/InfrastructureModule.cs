[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Payments.Api")]
namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure;

using Application;
using Application.Common.Contracts;
using Events;
using Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using PaymentProcessors;
using Persistance;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddPersistanceModule(configuration);
        services.AddEvents();
        services.AddPaymentsProcessors();
        services.AddScoped<IPaymentsModule, PaymentsModule>();

        return services;
    }

    internal static void UseInfrastructure(this IApplicationBuilder app)
    {
        app.UsePersistanceModule();
        app.UsePaymentProcessors();
    }
}
