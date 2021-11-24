namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class SuggestValuationMailConfiguration : ConfigurationBase, ISuggestValuationMailConfiguration
{
    public SuggestValuationMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(SuggestValuationMailConfiguration))
    {
    }

    public string Subject => configurationSection[nameof(Subject)];
    public string PathToTemplate => configurationSection[nameof(PathToTemplate)];
    public string RejectProposalLink => configurationSection[nameof(RejectProposalLink)];
    public string AcceptProposalLink => configurationSection[nameof(AcceptProposalLink)];
}
