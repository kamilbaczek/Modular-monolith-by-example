using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender
{
    internal interface IConfirmAccountMailSender
    {
        Task SendConfirmationEmailAsync(string email, string token, Guid userId);
    }
}