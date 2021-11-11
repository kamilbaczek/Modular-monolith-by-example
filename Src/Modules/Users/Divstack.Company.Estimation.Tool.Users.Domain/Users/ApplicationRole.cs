using Microsoft.AspNetCore.Identity;

namespace Divstack.Company.Estimation.Tool.Users.Domain.Users;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; }
}
