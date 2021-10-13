using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Users.Api
{
    internal static class UsersModule
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}