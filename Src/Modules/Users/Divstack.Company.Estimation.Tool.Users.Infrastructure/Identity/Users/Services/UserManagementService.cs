using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication;
using Divstack.Company.Estimation.Tool.Users.Application.Authentication.DTOs;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Commands.CreateUser.Requests;
using Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetAllUsers;
using Divstack.Company.Estimation.Tool.Users.Domain;
using Divstack.Company.Estimation.Tool.Users.Domain.Users;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Errors;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

internal sealed class UserManagementService : IUserManagementService
{
    private readonly ApplicationUserManager _applicationUserManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UserManagementService(
        ApplicationUserManager applicationUserManager,
        IDateTimeProvider dateTimeProvider,
        ICurrentUserService currentUserService)
    {
        _applicationUserManager = applicationUserManager;
        _dateTimeProvider = dateTimeProvider;
        _currentUserService = currentUserService;
    }

    public async Task<Guid> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        var applicationUser = UserAccount.Create(
            createUserRequest.FirstName,
            createUserRequest.LastName,
            createUserRequest.IsActive,
            createUserRequest.Email);

        var result = await _applicationUserManager.CreateAsync(applicationUser);
        if (result.Succeeded)
        {
            return applicationUser.PublicId;
        }

        var errors = result.Errors.Select(identityError => identityError.Code).ToList();

        if (errors.Contains(IndentityErrorsCodes.UsernameAlreadyTaken))
        {
            throw new UserNameAlreadyTakenException(createUserRequest.UserName);
        }

        throw new UserNotCreatedException(errors);
    }

    public async Task UpdateAsync(UpdateUserDto updateUserDto)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.PublicId == updateUserDto.PublicId);
        user.Update(
            updateUserDto.FirstName,
            updateUserDto.LastName,
            updateUserDto.IsActive,
            updateUserDto.Email);

        var result = await _applicationUserManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return;
        }

        var errors = result.Errors.Select(x => x.Code).ToList();

        if (errors.Contains(IndentityErrorsCodes.UsernameAlreadyTaken))
        {
            throw new UserNameAlreadyTakenException(user.UserName);
        }

        throw new UserNotUpdatedException(errors);
    }

    public async Task<bool> UserExists(string userName)
    {
        var user = await _applicationUserManager.Users.SingleOrDefaultAsync(u => u.UserName == userName);

        return user != null;
    }

    public async Task AssignUserToRoleAsync(string userName, string roleName)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.UserName == userName);
        await _applicationUserManager.AddToRoleAsync(user, roleName);
    }

    public async Task AssignUserToRolesAsync(Guid userPublicId, List<string> rolesNames)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.PublicId == userPublicId);
        await _applicationUserManager.AddToRolesAsync(user, rolesNames);
    }

    public async Task UpdateAssignedRolesAsync(Guid userPublicId, List<string> newRolesNames)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.PublicId == userPublicId);
        var userRoles = await _applicationUserManager.GetRolesAsync(user);
        await _applicationUserManager.RemoveFromRolesAsync(user, userRoles);
        await _applicationUserManager.AddToRolesAsync(user, newRolesNames);
    }

    public async Task DeleteAsync(Guid userPublicId, CancellationToken cancellationToken = default)
    {
        var user = await _applicationUserManager.Users.SingleAsync(x => x.PublicId == userPublicId,
            cancellationToken);
        var currentUserPublicId = _currentUserService.GetPublicUserId();
        user.Delete(_dateTimeProvider, currentUserPublicId);
        await _applicationUserManager.UpdateAsync(user);
    }

    public async Task<UserDetailsDto> GetUserDetailsAsync(string userName)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.UserName == userName);
        return await MapUserToUserDetailsDto(user);
    }

    public async Task<UserDetailsDto> GetUserDetailsByPublicIdAsync(Guid userPublicId)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.PublicId == userPublicId);
        return await MapUserToUserDetailsDto(user);
    }

    public async Task<UserDetailsDto> GetUserDetailsByUsernameAsync(string username)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.UserName == username);
        return await MapUserToUserDetailsDto(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _applicationUserManager.Users.ToListAsync();
        var userList = new List<UserDto>();
        foreach (var user in users)
        {
            var userRoles = await _applicationUserManager.GetRolesAsync(user);
            var userDto = new UserDto(
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.PublicId,
                userRoles.ToArray(),
                user.IsActive);

            userList.Add(userDto);
        }

        var orderedUsers = userList.OrderBy(user => user.UserName);

        return orderedUsers;
    }

    public async Task<IList<string>> GetUserRolesAsync(string userName)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.UserName == userName);
        return await GetUserRolesAsync(user);
    }

    public async Task<IList<string>> GetUserRolesAsync(Guid userPublicId)
    {
        var user = await _applicationUserManager.Users.SingleAsync(u => u.PublicId == userPublicId);
        return await GetUserRolesAsync(user);
    }

    private async Task<UserDetailsDto> MapUserToUserDetailsDto(UserAccount userAccount)
    {
        var userDetailsDto = new UserDetailsDto
        {
            UserName = userAccount.UserName,
            Email = userAccount.Email,
            FirstName = userAccount.FirstName,
            LastName = userAccount.LastName,
            PublicId = userAccount.PublicId,
            IsActive = userAccount.IsActive,
            PasswordExpirationDate = userAccount.PasswordExpirationDate
        };
        var roles = await _applicationUserManager.GetRolesAsync(userAccount);
        userDetailsDto.Roles = roles.ToArray();
        return userDetailsDto;
    }

    public async Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync(Guid userPublicId)
    {
        var users = await _applicationUserManager.Users.ToListAsync();
        var currentUser = users.First(x => x.PublicId == userPublicId);
        var userList = new List<UserDto>();
        foreach (var user in users)
        {
            var userRoles = await _applicationUserManager.GetRolesAsync(user);
            var userDto = new UserDto(
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.PublicId,
                userRoles.ToArray(),
                user.IsActive);

            userList.Add(userDto);
        }

        return userList.Where(u => !u.Roles.Any(role => ApplicationRoleKeys.SystemAdmins.Contains(role)));
    }

    public async Task<IEnumerable<UserDetailsDto>> GetAllUserDetails()
    {
        var users = await _applicationUserManager.Users.ToListAsync();
        return users.Select(u => new UserDetailsDto
        {
            UserName = u.UserName,
            PublicId = u.PublicId,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email
        });
    }

    private async Task<IList<string>> GetUserRolesAsync(UserAccount userAccount)
    {
        var roles = await _applicationUserManager.GetRolesAsync(userAccount);
        return roles;
    }

    private async Task SendConfirmationEmailAsync(UserAccount userAccount)
    {
        var confirmAccountToken = await _applicationUserManager.GenerateEmailConfirmationTokenAsync(userAccount);
    }
}
