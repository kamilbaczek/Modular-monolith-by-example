using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Contracts;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Products.DAL")]
namespace Divstack.Company.Estimation.Tool.Products.Core
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
                .FromAssemblyOf<ProductsService>()
                .AddClasses(c => c.Where(@class => @class.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<ProductExistingChecker>()
                .AddClasses(c => c.Where(@class => @class.Name.EndsWith("Checker")))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        }
    }
}
