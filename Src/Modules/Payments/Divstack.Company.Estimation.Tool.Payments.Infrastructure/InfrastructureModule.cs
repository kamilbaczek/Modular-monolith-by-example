using Divstack.Company.Estimation.Tool.Payments.Application;
using Divstack.Company.Estimation.Tool.Payments.Application.Common.Contracts;
using Divstack.Company.Estimation.Tool.Payments.Infrastructure.Events;
using Divstack.Company.Estimation.Tool.Payments.Infrastructure.Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Payments.Api")]

namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddEvents();
        services.AddScoped<IPaymentsModule, PaymentsModule>();

        return services;
    }

    internal static void UseInfrastructure(this IApplicationBuilder app)
    {
    }
}
