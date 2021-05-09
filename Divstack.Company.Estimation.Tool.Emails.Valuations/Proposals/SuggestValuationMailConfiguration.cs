using Divstack.Company.Estimation.Tool.Shared.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals
{
    internal class SuggestValuationMailConfiguration : ConfigurationBase, ISuggestValuationMailConfiguration
    {
        public SuggestValuationMailConfiguration(IConfiguration configuration) : base(configuration, "SuggestValuationMailConfiguration")
        {
        }

        public string Subject => configurationSection.GetValue<string>(nameof(Subject));
        public string PathToTemplate => configurationSection.GetValue<string>(nameof(PathToTemplate));
        public string RejectProposalLink => configurationSection.GetValue<string>(nameof(AcceptProposalLink));
        public string AcceptProposalLink => configurationSection.GetValue<string>(nameof(AcceptProposalLink));

    }
}
