using System;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Errors;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;
using Divstack.Company.Estimation.Tool.Users.Persistance.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity
{
    internal static class IdentityModule
    {
        internal static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            return services.AddIdentity<UsersContext>();
        }

        private static IServiceCollection AddIdentity<T>(this IServiceCollection services) where T : DbContext
        {
            var lockoutOptions = new LockoutOptions
            {
                AllowedForNewUsers = true,
                DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15),
                MaxFailedAccessAttempts = 3
            };

            services.AddIdentity<UserAccount, ApplicationRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.Password.RequiredLength = 8;
                    config.Password.RequireLowercase = true;
                    config.Password.RequireUppercase = true;
                    config.Password.RequireDigit = true;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Lockout = lockoutOptions;
                    config.Stores.MaxLengthForKeys = 85;
                })
                .AddUserManager<ApplicationUserManager>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<T>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}