using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Application;
using Divstack.Company.Estimation.Tool.Estimations.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Estimations.Api")]
namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure
{
    internal static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceModule(configuration);
            services.AddApplicationModule();

            return services;
        }
    }
}
