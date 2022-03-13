namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Services;

using Microsoft.Extensions.DependencyInjection;
using Tool.Priorities.Domain;

internal static class Extensions
{
    internal static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IPrioritiesRedefiner, PrioritesRedefiner>();

        return services;
    }
}
