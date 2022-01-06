using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Services.DataAccess")]

namespace Divstack.Company.Estimation.Tool.Services.Core;

using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Services;

internal static class CoreModule
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.RegisterServices();
        return services;
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ServicesService>()
            .AddClasses(c => c.Where(@class => @class.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        services.Scan(scan => scan
            .FromAssemblyOf<ServiceExistingChecker>()
            .AddClasses(c => c.Where(@class => @class.Name.EndsWith("Checker")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }
}
