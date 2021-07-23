using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ConfirmAccount.Sender
{
    internal interface IConfirmAccountMailSender
    {
        void Send(string email, string token, Guid userId);
    }
}
