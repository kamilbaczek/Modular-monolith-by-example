﻿using System.Reflection;
using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users
{
    internal static class EmailUsersModule
    {
        internal static IServiceCollection AddEmailUsers(this IServiceCollection services)
        {
            services.AddScoped<IConfirmAccountMailConfiguration, ConfirmAccountMailConfiguration>();
            services.AddScoped<IConfirmAccountMailSender, ConfirmAccountMailSender>();

            services.AddScoped<IPasswordExpiredMailConfiguration, PasswordExpiredMailConfiguration>();
            services.AddScoped<IPasswordExpiredMailSender, PasswordExpiredMailSender>();

            services.AddScoped<IForgotPasswordMailConfiguration, ForgotPasswordMailConfiguration>();
            services.AddScoped<IForgotPasswordMailSender, ForgotPasswordMailSender>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}