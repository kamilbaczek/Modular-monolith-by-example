using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Seeders.Request
{
    internal static class SeedersModule
    {
        internal static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddHostedService<ValuationRequestSeeder>();

            return services;
        }
    }
}