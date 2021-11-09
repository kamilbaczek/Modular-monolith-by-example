using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Domain.Users.Interfaces;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Configuration;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Passwords;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Seeder;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users
{
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
}