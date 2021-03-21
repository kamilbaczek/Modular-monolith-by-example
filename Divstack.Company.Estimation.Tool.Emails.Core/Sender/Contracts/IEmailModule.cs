using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts
{
    public interface IEmailModule
    {
        Task SendEmailAsync(string email, string subject, string text);
    }
}