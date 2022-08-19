namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Policies;

using Microsoft.AspNetCore.Authorization;

public class TokenValidAuthorizeAttribute : AuthorizeAttribute
{
    public TokenValidAuthorizeAttribute(string roles)
    {
        Policy = PolicyNameKeys.TokenValid;
        Roles = roles;
    }
}
