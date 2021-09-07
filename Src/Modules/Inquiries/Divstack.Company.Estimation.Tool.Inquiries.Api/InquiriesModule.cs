using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Inquiries.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.UserAccess;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Inquiries.Api
{
    internal static class InquiriesModule
    {
        public static IServiceCollection AddInquiriesModule(this IServiceCollection services,
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
