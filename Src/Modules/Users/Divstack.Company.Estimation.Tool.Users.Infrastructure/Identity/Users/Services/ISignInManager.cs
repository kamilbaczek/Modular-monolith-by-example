namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

internal interface ISignInManager
{
    Task SignOutAsync();

    Task<SignInResult> PasswordSignInAsync(UserAccount user, string password,
        bool isPersistent, bool lockoutOnFailure);
}
