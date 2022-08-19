namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Policies;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RefreshTokens;

public class TokenValidAuthorizationHandler : AuthorizationHandler<TokenValidRequirement>
{
    private readonly ITokenStoreManager tokenStoreManager;

    public TokenValidAuthorizationHandler(ITokenStoreManager tokenStoreManager)
    {
        this.tokenStoreManager = tokenStoreManager;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        TokenValidRequirement requirement)
    {
        if (context.User.Identity.IsAuthenticated && await tokenStoreManager.IsCurrentTokenActiveAsync())
        {
            context.Succeed(requirement);
        }
    }
}
