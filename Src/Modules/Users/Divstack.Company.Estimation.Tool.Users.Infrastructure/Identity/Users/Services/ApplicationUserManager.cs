namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authentication;
using Domain;
using Domain.Users;
using Domain.Users.Interfaces;
using Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public sealed class ApplicationUserManager : UserManager<UserAccount>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IPasswordComparer _passwordComparer;
    private readonly IUsersConfiguration _usersConfiguration;

    public ApplicationUserManager(
        IUserStore<UserAccount> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<UserAccount> passwordHasher,
        IEnumerable<IUserValidator<UserAccount>> userValidators,
        IEnumerable<IPasswordValidator<UserAccount>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<UserManager<UserAccount>> logger,
        IUsersConfiguration usersConfiguration,
        IDateTimeProvider dateTimeProvider,
        ICurrentUserService currentUserService,
        IPasswordComparer passwordComparer
    ) : base(
        store,
        optionsAccessor,
        passwordHasher,
        userValidators,
        passwordValidators,
        keyNormalizer,
        errors,
        services,
        logger)
    {
        _usersConfiguration = usersConfiguration;
        _dateTimeProvider = dateTimeProvider;
        _currentUserService = currentUserService;
        _passwordComparer = passwordComparer;
    }

    public override async Task<IdentityResult> ResetPasswordAsync(
        UserAccount userAccount,
        string token,
        string newPassword)
    {
        var passwordRepeated = userAccount.IsPasswordRepeated(
            newPassword,
            _dateTimeProvider,
            _usersConfiguration,
            _passwordComparer);
        if (passwordRepeated)
        {
            return IdentityResult.Failed(CustomIdentityErrorDescriber.PasswordRepeated);
        }

        var result = await base.ResetPasswordAsync(userAccount, token, newPassword);
        if (!result.Succeeded)
        {
            return IdentityResult.Failed(CustomIdentityErrorDescriber.TokenExpired);
        }

        userAccount.ArchivePassword(userAccount.PasswordHash, _dateTimeProvider);
        userAccount.RenewPasswordExpiration(_dateTimeProvider, _usersConfiguration);

        return await UpdateUserAsync(userAccount);
    }

    public override async Task<IdentityResult> AddPasswordAsync(
        UserAccount userAccount,
        string password)
    {
        var result = await base.AddPasswordAsync(userAccount, password);
        if (!result.Succeeded)
        {
            return result;
        }

        userAccount.ArchivePassword(userAccount.PasswordHash, _dateTimeProvider);
        userAccount.RenewPasswordExpiration(_dateTimeProvider, _usersConfiguration);

        return await UpdateUserAsync(userAccount);
    }

    private UserAccount GetChangedBy(UserAccount userAccount)
    {
        var currentUserPublicId = _currentUserService.GetPublicUserId();
        var changedBy = currentUserPublicId.Equals(userAccount.PublicId)
            ? userAccount
            : Users.SingleOrDefault(c => c.PublicId == currentUserPublicId);

        return changedBy;
    }
}
