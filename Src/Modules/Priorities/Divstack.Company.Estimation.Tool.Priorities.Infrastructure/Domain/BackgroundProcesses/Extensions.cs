namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.BackgroundProcesses;

using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    internal static IServiceCollection AddBackgroundProcesses(this IServiceCollection services)
    {
        services.AddHostedService<RedefinePrioritiesScheduler>();

        return services;
    }
}
