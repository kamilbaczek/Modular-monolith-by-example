namespace Divstack.Company.Estimation.Tool.Users.Domain.Users;

using System;

public sealed class PasswordHistory
{
    private PasswordHistory(
        UserAccount userAccount,
        string password,
        IDateTimeProvider dateTimeProvider)
    {
        UserAccount = userAccount;
        Password = password;
        ChangeDate = dateTimeProvider.Now;
    }

    private PasswordHistory()
    {
    }

    private long Id { get; }
    private UserAccount UserAccount { get; }
    public string Password { get; set; }
    public DateTime ChangeDate { get; set; }

    internal static PasswordHistory ArchivePassword(
        UserAccount userAccount,
        string password,
        IDateTimeProvider dateTimeProvider)
    {
        return new PasswordHistory(userAccount, password, dateTimeProvider);
    }
}
