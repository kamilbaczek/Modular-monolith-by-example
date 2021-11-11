using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.RefreshTokens;
using Microsoft.AspNetCore.Authorization;

namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Jwt.Policies;

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
            context.Succeed(requirement);
    }
}
