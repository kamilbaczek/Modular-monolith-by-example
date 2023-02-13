namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.Repositories;

using Domain.Inquiries;

internal static class RepositoriesModule
{
    private const string Repository = "Repository";
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<InquiriesRepository>()
            .AddClasses(implementationTypeFilter =>
                implementationTypeFilter.Where(type => type.Name.EndsWith(Repository, StringComparison.InvariantCultureIgnoreCase)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
