#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Users.Domain.Users;

using System;

public sealed class FailedLoginAttempt
{
    private FailedLoginAttempt()
    {
        // only for EF
    }

    private FailedLoginAttempt(UserAccount userAccount, DateTime loginDate)
    {
        UserAccount = userAccount;
        LoginDate = loginDate;
    }

    private long Id { get; }

    private UserAccount UserAccount { get; }
    private DateTime LoginDate { get; }

    internal static FailedLoginAttempt Create(UserAccount userAccount, DateTime loginDate)
    {
        return new FailedLoginAttempt(userAccount, loginDate);
    }
}
