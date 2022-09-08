namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System.Threading;
using System.Threading.Tasks;

public record struct SignInRequest(string UserName, string Password);

public interface ISignInManagementService
{
    Task<SignInResultStatus> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
    Task SignOutAsync();
    Task SaveLogForFailedLoginAttemptAsync(string userName, CancellationToken cancellationToken = default);
}
