namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Microsoft.Extensions.DependencyInjection;

internal static class RepositoriesModule
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ValuationsRepository>()
            .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
