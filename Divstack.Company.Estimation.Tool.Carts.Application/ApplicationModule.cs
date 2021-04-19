using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Carts.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Carts.Application
{
    internal static class ApplicationModule
    {
        internal static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            return services;
        }
    }
}