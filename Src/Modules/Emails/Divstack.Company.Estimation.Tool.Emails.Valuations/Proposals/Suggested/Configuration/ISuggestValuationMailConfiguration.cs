namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Configuration;

internal interface ISuggestValuationMailConfiguration
{
    string Subject { get; }
    string PathToTemplate { get; }
    string RejectProposalLink { get; }
    string AcceptProposalLink { get; }
}
