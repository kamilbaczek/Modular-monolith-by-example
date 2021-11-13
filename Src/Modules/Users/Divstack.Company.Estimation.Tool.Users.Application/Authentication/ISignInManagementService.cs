namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System.Threading;
using System.Threading.Tasks;

public interface ISignInManagementService
{
    Task<SignInResultStatus> SignInAsync(string userName, string password);
    Task SignOutAsync();
    Task SaveLogForFailedLoginAttemptAsync(string userName, CancellationToken cancellationToken = default);
}
