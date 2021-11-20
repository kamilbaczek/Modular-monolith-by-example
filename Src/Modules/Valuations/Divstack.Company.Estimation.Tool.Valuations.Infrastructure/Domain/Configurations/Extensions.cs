namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;
using Valuations.Domain.Valuations.Deadlines;

internal static class Extensions
{
    internal static IServiceCollection AddDeadlines(this IServiceCollection services)
    {
        services.AddSingleton<IDeadlinesConfiguration, DeadlinesConfiguration>();

        return services;
    }
}
