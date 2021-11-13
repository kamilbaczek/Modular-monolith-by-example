namespace Divstack.Company.Estimation.Tool.Payments.Persistance.Domain.Payments.Repositories;

using Microsoft.Extensions.DependencyInjection;

internal static class RepositoriesModule
{
    private const string Repository = "Repository";
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<PaymentsRepository>()
            .AddClasses(c => c.Where(type => type.Name.EndsWith(Repository)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
