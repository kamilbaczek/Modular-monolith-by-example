using System.Reflection;
using System.Runtime.CompilerServices;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Sender;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Emails.DependencyInjection")]
namespace Divstack.Company.Estimation.Tool.Emails.Valuations
{
    internal static class ValuationsModule
    {
        internal static IServiceCollection AddValuations(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IValuationProposalSuggestedMailSender, ValuationProposalSuggestedMailSender>();
            services.AddSingleton<ISuggestValuationMailConfiguration, SuggestValuationMailConfiguration>();

            return services;
        }
    }
}
