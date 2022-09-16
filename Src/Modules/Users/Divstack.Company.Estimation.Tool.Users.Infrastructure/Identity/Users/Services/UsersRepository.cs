namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly UserManager<UserAccount> _userManager;

    public UsersRepository(UserManager<UserAccount> userManager) => _userManager = userManager;

    public async Task<UserAccount> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
        => await _userManager.Users.SingleOrDefaultAsync(userAccount => userAccount.UserName.ToLower() == userName.ToLower(), cancellationToken: cancellationToken);

    public async Task UpdateAsync(UserAccount userAccount, CancellationToken cancellationToken = default)
        => await _userManager.UpdateAsync(userAccount);
}
