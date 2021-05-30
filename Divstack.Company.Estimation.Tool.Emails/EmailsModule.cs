using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Emails.Valuations;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core;
using Divstack.Company.Estimation.Tool.Modules.Emails.Users;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]
namespace Divstack.Company.Estimation.Tool.Modules.Emails.Bootstrapper
{
    internal static class EmailsModule
    {
        internal static IServiceCollection AddEmailsModule(this IServiceCollection services)
        {
            services.AddEmailCore();
            services.AddEmailUsers();
            services.AddValuations();

            return services;
        }
    }
}
