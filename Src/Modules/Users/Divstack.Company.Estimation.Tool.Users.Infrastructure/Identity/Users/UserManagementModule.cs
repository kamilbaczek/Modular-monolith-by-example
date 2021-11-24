namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users;

using Application.Authentication;
using Configuration;
using Domain.Users.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Passwords;
using Seeder;
using Services;

internal static class UserManagementModule
{
    internal static void AddUserManagementModule(this IServiceCollection services)
    {
        services.AddSingleton<IUsersConfiguration, UsersConfiguration>();
        services.AddSingleton<IAdminAccountConfiguration, AdminAccountConfiguration>();
        services.AddScoped<IUserManagementService, UserManagementService>();
        services.AddScoped<ISignInManagementService, SignInManagementService>();
        services.AddScoped<IRoleManagementService, RoleManagementService>();
        services.AddScoped<IPasswordComparer, PasswordComparer>();
        services.AddScoped<IPasswordsManagementService, PasswordsManagementService>();
        services.AddUserSeeder();
    }
}
