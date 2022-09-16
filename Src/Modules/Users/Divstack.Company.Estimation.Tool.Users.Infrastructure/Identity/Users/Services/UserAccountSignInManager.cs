namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

internal sealed class UserAccountSignInManager : ISignInManager
{
    private readonly SignInManager<UserAccount> _signInManager;
    public UserAccountSignInManager(SignInManager<UserAccount> signInManager) => _signInManager = signInManager;

    public async Task SignOutAsync() => await _signInManager.SignOutAsync();

    public async Task<SignInResult> PasswordSignInAsync(UserAccount user, string password, bool isPersistent, bool lockoutOnFailure) => await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
}
