using Divstack.Company.Estimation.Tool.Carts.Persistance.Domain.Carts;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.Repositories
{
    internal static class RepositoriesModule
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<CartsRepository>()
                .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}
