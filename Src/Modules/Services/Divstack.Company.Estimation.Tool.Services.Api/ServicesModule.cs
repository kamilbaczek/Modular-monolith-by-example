using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Services.Api.UserAccess;
using Divstack.Company.Estimation.Tool.Services.Core.UserAccess;
using Divstack.Company.Estimation.Tool.Services.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Services.Api
{
    internal static class ServicesModule
    {
        public static IServiceCollection AddServicesModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDataAccess(configuration);
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}