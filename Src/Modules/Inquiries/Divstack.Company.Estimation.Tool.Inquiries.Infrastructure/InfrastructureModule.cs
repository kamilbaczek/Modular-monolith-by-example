[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Api")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure;

using Application;
using Application.Common.Contracts;
using Events;
using Mediation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Persistance;

internal static class InfrastructureModule
{
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistanceModule(configuration);
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddEvents();
        services.AddScoped<IInquiriesModule, InquiriesModule>();

        return services;
    }

    internal static void UseInfrastructure(this IApplicationBuilder app)
    {
    }
}
