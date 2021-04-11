using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Estimations.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Estimations.Api
{
    internal static class ValuationModule
    {
        public static IServiceCollection AddCartsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
