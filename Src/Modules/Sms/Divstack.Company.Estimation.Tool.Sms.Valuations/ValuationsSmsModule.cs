using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Sms")]
namespace Divstack.Estimation.Tool.Sms.Valuations;

using Microsoft.Extensions.DependencyInjection;
using Notifications.Proposals.ProposalSuggested;

internal static class ValuationsSmsModule
{
    private const string Configuration = "Configuration";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<ProposalSuggestedSmsNotificationHandler>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}
