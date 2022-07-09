[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Inquiries.Api")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure;

using Application;
using Application.Common.Contracts;
using Events;
using Mediation;
using Microsoft.Extensions.Configuration;
using Persistance;

internal static class InfrastructureModule
{
    internal static void AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPersistanceModule(configuration);
        services.AddApplicationModule();
        services.AddMediationModule();
        services.AddEvents();
        services.AddScoped<IInquiriesModule, InquiriesModule>();
    }
}
