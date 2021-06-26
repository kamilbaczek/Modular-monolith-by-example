using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.EventBus;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Mediation;
using Divstack.Company.Estimation.Tool.Estimations.Persistance;
using Divstack.Company.Estimation.Tool.Valuations.Application;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Integrations.Trello;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Api")]

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure
{
    internal static class InfrastructureModule
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPersistanceModule(configuration);
            services.AddApplicationModule();
            services.AddMediationModule();
            services.AddTrello();
            services.AddScoped<IValuationsModule, ValuationsModule>();
            services.AddScoped<IEventPublisher, EventPublisher>();

            return services;
        }

        internal static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseTrello();
        }
    }
}