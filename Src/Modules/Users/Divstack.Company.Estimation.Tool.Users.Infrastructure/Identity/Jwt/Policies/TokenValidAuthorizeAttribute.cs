using Microsoft.AspNetCore.Authorization;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Policies;

public class TokenValidAuthorizeAttribute : AuthorizeAttribute
{
    public TokenValidAuthorizeAttribute(string roles)
    {
        Policy = PolicyNameKeys.TokenValid;
        Roles = roles;
    }
}
