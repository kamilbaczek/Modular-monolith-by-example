namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Configuration
{
    internal interface IValuationProposalApprovedMailConfiguration
    {
        string Subject { get; }
        string PathToTemplate { get; }
        string ApprovedProposalLink { get; }
    }
}
