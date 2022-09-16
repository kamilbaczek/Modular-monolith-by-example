namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Passwords;

using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Services;

internal sealed class PasswordTokens : IPasswordTokens
{
    private readonly UserManager<UserAccount> _userManager;

    public PasswordTokens(UserManager<UserAccount> userManager) => _userManager = userManager;

    public async Task<string> GeneratePasswordResetTokenAsync(UserAccount userAccount) =>
        await _userManager.GeneratePasswordResetTokenAsync(userAccount);
}
