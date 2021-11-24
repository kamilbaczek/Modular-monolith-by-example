namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetAllUsers;

using System;

public sealed record UserDto(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    Guid PublicId,
    string[] Roles,
    bool IsActive);
