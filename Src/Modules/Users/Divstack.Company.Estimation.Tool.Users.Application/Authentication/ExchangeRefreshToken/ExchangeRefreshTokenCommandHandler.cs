namespace Divstack.Company.Estimation.Tool.Users.Application.Authentication.ExchangeRefreshToken;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ExchangeRefreshTokenCommandHandler : IRequestHandler<ExchangeRefreshTokenCommand,
    ActionResult<ExchangeRefreshTokenResponse>>
{
    private readonly IJwtTokenManagementService _jwtTokenManagementService;
    private readonly IRefreshTokenGenerationService _refreshTokenGenerationService;
    private readonly IUserManagementService _userManagementService;

    public ExchangeRefreshTokenCommandHandler(IJwtTokenManagementService jwtTokenManagementService,
        IUserManagementService userManagementService, IRefreshTokenGenerationService refreshTokenGenerationService)
    {
        _jwtTokenManagementService = jwtTokenManagementService;
        _userManagementService = userManagementService;
        _refreshTokenGenerationService = refreshTokenGenerationService;
    }

    public async Task<ActionResult<ExchangeRefreshTokenResponse>> Handle(ExchangeRefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var userPublicId = _jwtTokenManagementService.GetUserPublicIdFromToken(request.Token);
        var isAuthorized =
            await _refreshTokenGenerationService.HasValidRefreshTokenAsync(userPublicId, request.RefreshToken);
        if (!isAuthorized)
        {
            return new UnauthorizedResult();
        }

        var userDetails = await _userManagementService.GetUserDetailsByPublicIdAsync(userPublicId);
        var userRoles = await _userManagementService.GetUserRolesAsync(userDetails.Email);

        var newJwtToken = _jwtTokenManagementService.GenerateJwtToken(userDetails, userRoles);
        var newRefreshToken = await _refreshTokenGenerationService.GenerateRefreshTokenAsync(userDetails.PublicId);

        return new ExchangeRefreshTokenResponse(newJwtToken, newRefreshToken);
    }
}
