namespace Divstack.Estimation.Tool.Sms.Valuations.Notifications.Proposals.ProposalSuggested.Configuration;

using Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

internal sealed class SuggestValuationSmsConfiguration : ConfigurationBase, ISuggestValuationSmsConfiguration
{
    public SuggestValuationSmsConfiguration(IConfiguration configuration) : base(configuration,
        nameof(SuggestValuationSmsConfiguration))
    {
    }

    public string RejectProposalLink => configurationSection[nameof(RejectProposalLink)];
    public string AcceptProposalLink => configurationSection[nameof(AcceptProposalLink)];
}
