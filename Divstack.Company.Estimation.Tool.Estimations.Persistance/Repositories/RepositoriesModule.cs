using Divstack.Company.Estimation.Tool.Estimations.Persistance.Domain.Valuations;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.Repositories
{
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
}
