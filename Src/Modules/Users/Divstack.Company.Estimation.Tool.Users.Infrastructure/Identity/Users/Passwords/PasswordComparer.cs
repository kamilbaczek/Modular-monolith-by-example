using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Domain.Users.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Passwords;

internal sealed class PasswordComparer : IPasswordComparer
{
    private readonly IPasswordHasher<UserAccount> _passwordHasher;

    public PasswordComparer(IPasswordHasher<UserAccount> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public bool AreEqual(UserAccount userAccount, string hashedPassword, string plainTextPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(userAccount, hashedPassword, plainTextPassword);
        return result == PasswordVerificationResult.Success;
    }
}
