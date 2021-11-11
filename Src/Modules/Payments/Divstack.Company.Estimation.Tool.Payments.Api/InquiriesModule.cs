using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Payments.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Payments.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Payments.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Payments.Api
{
    internal static class PaymentsModule
    {
        public static IServiceCollection AddInquiriesModules(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddInfrastructure(configuration);

            return services;
        }

        public static void UseInquiriesModule(this IApplicationBuilder app)
        {
            app.UseInfrastructure();
        }
    }
}