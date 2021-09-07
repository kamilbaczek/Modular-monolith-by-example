using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;
using Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]
namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov
{
    internal static class SnovModule
    {
        private const string HttpClient = "HttpClient";

        internal static IServiceCollection AddSnov(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<ClientCompanyFinder>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith(HttpClient)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.AddScoped<IClientCompanyFinder, ClientCompanyFinder>();

            return services;
        }
    }
}
