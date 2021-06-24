using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Estimations.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Estimations.Infrastructure;
using Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Estimations.Api
{
    internal static class ValuationModule
    {
        public static IServiceCollection AddValuationsModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddInfrastructure(configuration);

            return services;
        }

        public static void UseValuationModule(this IApplicationBuilder app)
        {
            app.UseInfrastructure();
        }
    }
}
