using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender
{
    internal interface IValuationProposalApprovedMailSender
    {
        Task SendEmailAsync(ValuationProposalApprovedEmailRequest request);
    }
}