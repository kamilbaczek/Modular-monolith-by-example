namespace Divstack.Company.Estimation.Tool.Users.Domain.Users;

using Microsoft.AspNetCore.Identity;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }
}
