namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DTOs;
using Users.Commands.CreateUser.Requests;
using Users.Queries.GetAllUsers;

public interface IUserManagementService
{
    Task<Guid> CreateUserAsync(CreateUserRequest createUserRequest);
    Task UpdateAsync(UpdateUserDto updateUserDto);
    Task UpdateAssignedRolesAsync(Guid userPublicId, List<string> newRolesNames);
    Task DeleteAsync(Guid userPublicId, CancellationToken cancellationToken = default);
    Task<bool> UserExists(string userName);
    Task AssignUserToRoleAsync(string userName, string roleName);
    Task AssignUserToRolesAsync(Guid userPublicId, List<string> rolesNames);
    Task<UserDetailsDto> GetUserDetailsAsync(string userName);
    Task<UserDetailsDto> GetUserDetailsByPublicIdAsync(Guid userPublicId);
    Task<UserDetailsDto> GetUserDetailsByUsernameAsync(string username);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<IList<string>> GetUserRolesAsync(string userName);
    Task<IList<string>> GetUserRolesAsync(Guid userPublicId);
}
