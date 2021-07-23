using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender
{
    internal interface IValuationCloseToDeadlineMailSender
    {
        Task SendEmailAsync(ValuationCloseToDeadlineEmailRequest request);
    }
}
