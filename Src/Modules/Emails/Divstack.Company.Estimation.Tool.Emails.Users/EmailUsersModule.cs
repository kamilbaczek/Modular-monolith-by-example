using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Users;

using System.Reflection;
using ConfirmAccount.Configuration;
using ConfirmAccount.Sender;
using ForgotPassword;
using ForgotPassword.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PasswordExpired;
using PasswordExpired.Configuration;

internal static class EmailUsersModule
{
    internal static IServiceCollection AddUsers(this IServiceCollection services)
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
