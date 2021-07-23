using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.ForgotPassword
{
    internal interface IForgotPasswordMailSender
    {
        void Send(string email, string token, Guid userId);
    }
}
