[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Priorities.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Priorities;

using Microsoft.Extensions.DependencyInjection;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        return services;
    }
}
