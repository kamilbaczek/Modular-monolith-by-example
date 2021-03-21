using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Carts.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Carts.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Carts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Carts.Api
{
    internal static class CartsModule
    {
        public static IServiceCollection AddCartsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
