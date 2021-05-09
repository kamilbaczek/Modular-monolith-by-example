using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Sender
{
    internal interface IValuationProposalSuggestedMailSender
    {
        Task SendEmailAsync(SuggestProposalEmailRequest request);
    }
}
