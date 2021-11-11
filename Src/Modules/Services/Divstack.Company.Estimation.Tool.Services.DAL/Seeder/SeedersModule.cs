using Divstack.Company.Estimation.Tool.Services.DAL.Seeder.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Services.DAL.Seeder;

internal static class SeedersModule
{
    internal static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddHostedService<ServicesSeeder>();

        return services;
    }
}
