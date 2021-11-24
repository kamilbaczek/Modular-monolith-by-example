namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IPasswordsManagementService
{
    Task<string> GenerateResetUserPasswordTokenAsync(Guid userPublicId);
    Task<string> GenerateConfirmAccountTokenAsync(Guid userPublicId);
    Task ForgotPasswordAsync(Guid userPublicId);

    Task<bool> ResetPasswordAsync(Guid userPublicId, string newPassword, string resetPasswordToken,
        CancellationToken cancellationToken = default);

    Task<bool> ChangeUserPasswordAsync(Guid userPublicId, string newPassword,
        CancellationToken cancellationToken = default);

    Task ConfirmUserEmailAndSetPasswordAsync(Guid userPublicId, string token, string password);
}
