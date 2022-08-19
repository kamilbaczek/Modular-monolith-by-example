namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserByUsername;

using System;

public class UserAccountDto
{
    public UserAccountDto(string userName, string email, Guid publicId, string[] roles)
    {
        UserName = userName;
        Email = email;
        PublicId = publicId;
        Roles = roles;
    }

    public string UserName { get; }
    public string Email { get; }
    public Guid PublicId { get; }
    public string[] Roles { get; }
}
