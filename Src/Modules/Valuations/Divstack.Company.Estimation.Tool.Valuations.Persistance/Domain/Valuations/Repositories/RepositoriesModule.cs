namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

using Microsoft.Extensions.DependencyInjection;

internal static class RepositoriesModule
{
    private const string Repository = "Repository";
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ValuationsRepository>()
            .AddClasses(@class => @class.Where(type => type.Name.EndsWith(Repository)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
