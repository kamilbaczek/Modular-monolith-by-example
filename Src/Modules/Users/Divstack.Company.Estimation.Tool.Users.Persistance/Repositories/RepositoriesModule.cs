namespace Divstack.Company.Estimation.Tool.Users.Persistance.Repositories;

using Domain.Users;
using Microsoft.Extensions.DependencyInjection;

internal static class RepositoriesModule
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<UserRepository>()
            .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
