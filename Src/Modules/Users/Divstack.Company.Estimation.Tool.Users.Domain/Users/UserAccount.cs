#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Users.Domain.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Identity;

public sealed class UserAccount : IdentityUser
{
    private UserAccount(
        string firstName,
        string lastName,
        string email,
        bool isActive)
    {
        PublicId = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        IsActive = isActive;
        PasswordExpirationDate = null;
        LastLoginDate = null;
        UserName = email;
        Email = email;
        FailedLoginAttempts = new List<FailedLoginAttempt>();
        ArchivedPasswords = new List<PasswordHistory>();
    }

    private UserAccount()
    {
    }

    public Guid PublicId { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime? PasswordExpirationDate { get; private set; }
    private DateTime? LastLoginDate { get; set; }
    private DateTime? Deleted { get; set; }
    private ICollection<FailedLoginAttempt> FailedLoginAttempts { get; }
    private ICollection<PasswordHistory> ArchivedPasswords { get; }

    public static UserAccount Create(
        string firstName,
        string lastName,
        bool isActive,
        string email)
    {
        return new UserAccount(firstName, lastName, email, isActive);
    }


    public void Update(
        string firstName,
        string lastName,
        bool isActive,
        string email)
    {
        UserName = email;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        IsActive = isActive;
    }

    public void RegisterFailedLoginAttempt(DateTime loginDate)
    {
        var failedLoginAttempt = FailedLoginAttempt.Create(this, loginDate);
        FailedLoginAttempts.Add(failedLoginAttempt);
    }

    public bool IsPasswordExpired(IDateTimeProvider datetimeProvider)
    {
        if (PasswordExpirationDate is null)
        {
            return false;
        }

        return datetimeProvider.NowDate > PasswordExpirationDate;
    }

    public void RenewPasswordExpiration(IDateTimeProvider datetimeProvider, IUsersConfiguration configuration)
    {
        var passwordChangeFrequency = configuration.PasswordExpirationFrequency;
        if (passwordChangeFrequency is 0)
        {
            PasswordExpirationDate = null;
        }
        else
        {
            PasswordExpirationDate = datetimeProvider.Now.AddDays(passwordChangeFrequency);
        }
    }

    public void ArchivePassword(string password, IDateTimeProvider dateTimeProvider)
    {
        var passwordHistory = PasswordHistory.ArchivePassword(this, password, dateTimeProvider);
        ArchivedPasswords.Add(passwordHistory);
    }

    public bool IsPasswordRepeated(string password,
        IDateTimeProvider dateTimeProvider,
        IUsersConfiguration configuration,
        IPasswordComparer passwordComparer)
    {
        var passwordCannotBeRepeatedPeriod = configuration.PasswordExpirationFrequency;
        if (passwordCannotBeRepeatedPeriod is 0)
        {
            return false;
        }

        var verificationStartDate = dateTimeProvider.Now.AddDays(-passwordCannotBeRepeatedPeriod);
        var passwordRepeated = ArchivedPasswords
            .Where(passwordHistory => passwordHistory.ChangeDate >= verificationStartDate)
            .Select(passwordHistory => passwordHistory.Password)
            .Any(hashedPassword => passwordComparer.AreEqual(this, hashedPassword, password));

        return passwordRepeated;
    }

    public void SignIn(IDateTimeProvider dateTimeProvider)
    {
        LastLoginDate = dateTimeProvider.Now;
    }

    public void Delete(IDateTimeProvider dateTimeProvider, Guid deletedByUserId)
    {
        Deleted = dateTimeProvider.Now;
    }
}
