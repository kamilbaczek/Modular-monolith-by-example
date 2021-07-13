using System;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Modules.Emails.Users.PasswordExpired
{
    internal interface IPasswordExpiredMailSender
    {
        Task SendResetPasswordEmailAsync(string email, string token, Guid userId);
    }
}