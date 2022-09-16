namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading;
using System.Threading.Tasks;
using Domain.Users;

internal interface IUsersRepository
{
    Task<UserAccount> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserAccount userAccount, CancellationToken cancellationToken = default);
}
