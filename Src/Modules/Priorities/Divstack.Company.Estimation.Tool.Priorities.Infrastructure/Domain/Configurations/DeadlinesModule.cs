namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;
using Tool.Priorities.Domain.Deadlines;

internal static class DeadlinesModule
{
    internal static IServiceCollection AddDeadlines(this IServiceCollection services)
    {
        services.AddSingleton<IDeadlinesConfiguration, DeadlinesConfiguration>();

        return services;
    }
}
