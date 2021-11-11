using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Inquiries.Application;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Events;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation;
using Divstack.Company.Estimation.Tool.Inquiries.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Api")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure;

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
