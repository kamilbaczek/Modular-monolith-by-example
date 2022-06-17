[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails")]

namespace Divstack.Company.Estimation.Tool.Emails.Valuations;

using Microsoft.Extensions.DependencyInjection;
using Proposals.Suggested;

internal static class ValuationsModule
{
    private const string Configuration = "Configuration";
    private const string Sender = "Sender";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
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
