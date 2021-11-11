using System.Threading;
using System.Threading.Tasks;

namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

public interface ISignInManagementService
{
    Task<SignInResultStatus> SignInAsync(string userName, string password);
    Task SignOutAsync();
    Task SaveLogForFailedLoginAttemptAsync(string userName, CancellationToken cancellationToken = default);
}
