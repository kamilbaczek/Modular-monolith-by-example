using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Users.Application;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;
using Divstack.Company.Estimation.Tool.Users.Domain;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Date;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Mediation;
using Divstack.Company.Estimation.Tool.Users.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Users.Api")]

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure
{
    internal static class InfrastructureModule
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplicationModule();
            services.AddMediationModule();
            services.AddJwtTokenAuthorizationModule(configuration);
            services.AddPersistanceModule(configuration);
            services.AddUserManagementModule();
            services.AddIdentity();
            services.AddScoped<IUserModule, UserModule>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}