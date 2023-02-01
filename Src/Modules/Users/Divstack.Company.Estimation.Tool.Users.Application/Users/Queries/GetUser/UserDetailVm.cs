namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

using System;

public record UserDetailVm(string FirstName, string LastName, string UserName, string Email, Guid PublicId, string[] Roles, bool IsActive, DateTime? PasswordExpirationDate);
