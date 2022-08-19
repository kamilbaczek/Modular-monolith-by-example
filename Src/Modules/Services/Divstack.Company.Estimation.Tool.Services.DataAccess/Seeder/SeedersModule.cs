namespace Divstack.Company.Estimation.Tool.Services.DataAccess.Seeder;

using Microsoft.Extensions.DependencyInjection;
using Services;

internal static class SeedersModule
{
    internal static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddHostedService<ServicesSeeder>();

        return services;
    }
}
