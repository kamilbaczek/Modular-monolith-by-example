using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Users.Api")]

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure;

using Application;
using Application.Contracts;
using Date;
using Domain;
using Identity;
using Identity.Jwt;
using Identity.Jwt.SignalR;
using Identity.Users;
using Mediation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance;

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
