using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Domain.Configurations
{
    internal static class Extensions
    {
        internal static IServiceCollection AddDeadlines(this IServiceCollection services)
        {
            services.AddSingleton<IDeadlinesConfiguration, DeadlinesConfiguration>();

            return services;
        }
    }
}
