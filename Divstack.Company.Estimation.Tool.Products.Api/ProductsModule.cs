using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Products.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Products.Core;
using Divstack.Company.Estimation.Tool.Products.Core.UserAccess;
using Divstack.Company.Estimation.Tool.Products.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Products.Api
{
    internal static class ProductsModule
    {
        public static IServiceCollection AddProductsModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
