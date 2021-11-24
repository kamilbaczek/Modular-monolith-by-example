[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Valuations.Application;

using Microsoft.Extensions.DependencyInjection;

internal static class ApplicationModule
{
    internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        return services;
    }
}
