using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Services.DAL")]

namespace Divstack.Company.Estimation.Tool.Services.Core
{
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
}