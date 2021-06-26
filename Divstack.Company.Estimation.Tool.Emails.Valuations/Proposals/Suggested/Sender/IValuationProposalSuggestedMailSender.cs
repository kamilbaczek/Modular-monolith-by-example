using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender
{
    internal interface IValuationProposalSuggestedMailSender
    {
        Task SendEmailAsync(ValuationProposalSuggestedEmailRequest request);
    }
}