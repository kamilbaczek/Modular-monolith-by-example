using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Valuations.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov;

using Domain.Inquiries.Clients;
using FindClientCompany;
using Microsoft.Extensions.DependencyInjection;

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
