namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;

using System.Threading.Tasks;

internal interface IValuationProposalSuggestedMailSender
{
    Task SendAsync(ValuationProposalSuggestedEmailRequest request);
}
