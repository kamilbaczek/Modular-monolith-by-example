using System;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

public class UserDetailVm
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public Guid PublicId { get; set; }
    public string[] Roles { get; set; }
    public bool IsActive { get; set; }
    public DateTime? PasswordExpirationDate { get; set; }
}
