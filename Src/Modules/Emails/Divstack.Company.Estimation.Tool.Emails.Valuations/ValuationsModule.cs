using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Valuations;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Proposals.Suggested;

internal static class ValuationsModule
{
    private const string Configuration = "Configuration";
    private const string Sender = "Sender";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Scan(scan => scan.FromAssemblyOf<ProposalSuggestedEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        services.Scan(scan => scan.FromAssemblyOf<ProposalSuggestedEventHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Sender)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
