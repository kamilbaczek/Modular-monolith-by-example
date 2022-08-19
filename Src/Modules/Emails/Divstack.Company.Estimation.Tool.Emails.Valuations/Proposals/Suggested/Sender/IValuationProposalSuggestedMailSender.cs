namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;

internal interface IValuationProposalSuggestedMailSender
{
    Task SendAsync(ValuationProposalSuggestedEmailRequest request);
}
